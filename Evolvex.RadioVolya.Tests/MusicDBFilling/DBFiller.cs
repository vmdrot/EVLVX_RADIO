using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace Evolvex.RadioVolya.Tests.MusicDBFilling
{
    [TestFixture]
    public class DBFiller
    {
        public class MP3info
        {
            public string Artist {get;set;}
            public String Title {get;set;}
            public String Album {get;set;}
            public int Year {get;set;}
            public String Genre {get;set;}
            public String PhysicalPath { get; set; }
            public String Comment {get;set;}
            public int AudioBitrate {get;set;}
            public int AudioChannels {get;set;}
            public int AudioSampleRate { get;set;}
            public int BitsPerSample {get;set;}
            public String Description {get;set;}
            public TimeSpan Duration { get; set; }

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
        }
        [Test]
        public void TraverseFolders()
        {
            string[] mp3s = Directory.GetFiles(@"D:\home\vmdrot\HaErez\RadioVolya\Sounds\Music", "*.mp3", SearchOption.AllDirectories);
            List<MP3info> infos = new List<MP3info>();
            foreach (string file in mp3s)
            {
                MP3info mp3i = GetMP3Info(file);
                if(mp3i != null)
                infos.Add(mp3i);
            }

            Console.WriteLine("infos.Count = {0}", infos.Count);
            using (StreamWriter sw = new StreamWriter(@"D:\home\vmdrot\HaErez\RadioVolya\Sounds\all.csv",false, Encoding.Unicode))
            {
                //Console.WriteLine("Title,Album,Year,Genre,PhysicalPath,Comment,AudioBitrate,AudioChannels,AudioSampleRate,BitsPerSample,Description,Duration");
                sw.WriteLine("Title,Album,Year,Genre,PhysicalPath,Comment,AudioBitrate,AudioChannels,AudioSampleRate,BitsPerSample,Description,Duration");
                foreach (MP3info info in infos)
                    sw.WriteLine(info.ToString());
                    //Console.WriteLine(info.ToString());
            }
        }

        private MP3info GetMP3Info(String path)
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
                return null;
            }
        }

        private string ChooseMoreComplete(string[] v1, string[] v2)
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

        private int ChooseMoreComplete(uint v1, uint v2)
        {
            if (v1 != 0)
                return (int)v1;
            else
                return (int)v2;
        }

        private string ChooseMoreComplete(String v1, String v2)
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
