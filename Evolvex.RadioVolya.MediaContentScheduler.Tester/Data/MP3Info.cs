using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using Evolvex.RadioVolya.GenericDAL.Enums;

namespace Evolvex.RadioVolya.MediaContentScheduler.Tester.Data
{
    public class MP3info
    {
        public MP3info()
        {
            Kind = TrackKind.Song;
        }

        public string Artist { get; set; }
        public String Title { get; set; }
        public String Album { get; set; }
        public int Year { get; set; }
        public String Genre { get; set; }
        public String PhysicalPath { get; set; }
        public String Comment { get; set; }
        public int AudioBitrate { get; set; }
        public int AudioChannels { get; set; }
        public int AudioSampleRate { get; set; }
        public int BitsPerSample { get; set; }
        public String Description { get; set; }
        public TimeSpan Duration { get; set; }
        public TrackKind Kind { get; set; }

        public override string ToString()
        {
            //return String.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}", Artist
            return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", Artist
, Title
, Album
, Year
, Genre
, PhysicalPath
, Comment
, AudioBitrate
, AudioChannels
, AudioSampleRate
, BitsPerSample
, Description
, Duration
);
        }

        public void ToXml(XmlWriter w)
        {
            const string PARENT_ELEM_NM = "Track";
            w.WriteStartElement(PARENT_ELEM_NM);
            w.WriteStartElement("Channels");
            w.WriteElementString("Channel", "target_channel_name_place_holder");
            w.WriteEndElement();
            w.WriteStartElement("Artists");
            if (!String.IsNullOrEmpty(Artist)) w.WriteElementString("Artist", this.Artist);
            w.WriteEndElement();
            if (!String.IsNullOrEmpty(Title)) w.WriteElementString("Title", this.Title);
            w.WriteElementString("Kind", this.Kind.ToString());
            if (!String.IsNullOrEmpty(Album)) w.WriteElementString("Album", this.Album);
            if (Year != 0 && Year != int.MaxValue && Year != int.MinValue) w.WriteElementString("Year", this.Year.ToString());
            w.WriteStartElement("Genres");
            if (!String.IsNullOrEmpty(Genre)) w.WriteElementString("Genre", this.Genre);
            w.WriteEndElement();
            w.WriteStartElement("Tags");
            //if (!String.IsNullOrEmpty(Genre)) w.WriteElementString("Genre", this.Genre);
            w.WriteEndElement();

            if (!String.IsNullOrEmpty(PhysicalPath)) w.WriteElementString("PhysicalPath", this.PhysicalPath);
            if (!String.IsNullOrEmpty(Comment)) w.WriteElementString("Comment", this.Comment);
            w.WriteElementString("AudioBitrate", this.AudioBitrate.ToString());
            w.WriteElementString("AudioChannels", this.AudioChannels.ToString());
            w.WriteElementString("AudioSampleRate", this.AudioSampleRate.ToString());
            if (BitsPerSample != 0) w.WriteElementString("BitsPerSample", this.BitsPerSample.ToString());
            if (!String.IsNullOrEmpty(Description)) w.WriteElementString("Description", this.Description);
            w.WriteElementString("Duration", this.Duration.ToString());
            string langNm = "uk";
            string countryNm = "UA";
            if (PhysicalPath.IndexOf("\\UA\\") == -1)
            {
                langNm = "en";
                countryNm = "US";
            }
            w.WriteStartElement("LCIDs");
            w.WriteElementString("LCID", langNm);
            w.WriteEndElement();
            w.WriteElementString("Country", countryNm);
            w.WriteElementString("RenameTo", GenerateRenameTo(this.PhysicalPath));
            w.WriteEndElement();
        }

        private string GenerateRenameTo(string oldPath)
        {
            String dir = Path.GetDirectoryName(oldPath);
            string filename = Path.GetFileName(oldPath);
            if (filename.IndexOf(' ') != -1)
                filename = filename.Replace(' ', '_');
            filename = filename.Replace("&", "and");
            return Path.Combine(dir, filename);

        }

        public static MP3info GetMP3Info(String path)
        {
            try
            {
                TagLib.File mp3file = TagLib.File.Create(path);
                MP3info rslt = new MP3info();
                TagLib.Tag tag1 = mp3file.GetTag(TagLib.TagTypes.Id3v1);
                TagLib.Tag tag2 = mp3file.GetTag(TagLib.TagTypes.Id3v2);
                TagLib.Properties props = mp3file.Properties;

                rslt.Artist = ChooseMoreComplete(tag1.Artists, tag2.Artists);
                rslt.Title = ChooseMoreComplete(tag1.Title, tag2.Title);
                rslt.Album = ChooseMoreComplete(tag1.Album, tag2.Album);
                rslt.Year = ChooseMoreComplete(tag1.Year, tag2.Year);
                rslt.Genre = ChooseMoreComplete(tag1.Genres, tag2.Genres);
                rslt.PhysicalPath = path;
                rslt.Comment = ChooseMoreComplete(tag1.Comment, tag2.Comment);
                rslt.AudioBitrate = props.AudioBitrate;
                rslt.AudioChannels = props.AudioChannels;
                rslt.AudioSampleRate = props.AudioSampleRate;
                rslt.BitsPerSample = props.BitsPerSample;
                rslt.Description = props.Description;
                rslt.Duration = props.Duration;
                return rslt;
            }
            catch (TagLib.CorruptFileException cfex)
            {
                return new MP3info() { PhysicalPath = path };
            }
        }

        private static string ChooseMoreComplete(string[] v1, string[] v2)
        {
            if ((v1 == null || v1.Length == 0) && (v2 == null || v2.Length == 0))
                return string.Empty;
            if (v1 == null || v1.Length == 0)
                return v2[0].Trim();
            else if (v2 == null || v2.Length == 0)
                return v1[0].Trim();
            else
                return ChooseMoreComplete(v1[0], v2[0]);

        }

        private static int ChooseMoreComplete(uint v1, uint v2)
        {
            if (v1 != 0)
                return (int)v1;
            else
                return (int)v2;
        }

        private static string ChooseMoreComplete(String v1, String v2)
        {
            if (String.IsNullOrEmpty(v1))
                return v2;
            else if (String.IsNullOrEmpty(v2))
                return v1;

            else if (v1.Trim().Length > v2.Trim().Length)
                return v1.Trim();
            else
                return v2.Trim();
        }
    }

}
