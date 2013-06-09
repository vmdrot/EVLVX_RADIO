using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.GenericDAL.Interfaces;
using System.Xml;
using Evolvex.RadioVolya.DAL.Models;
using System.Globalization;
using System.Xml.Linq;

namespace Evolvex.RadioVolya.DAL.Import
{
    public class XmlImporterEx
    {

        #region const(s)
        public const string TracksElement = "Tracks";
        public const string TrackElement = "Track";
        public const string ChannelsElement = "Channels";
        public const string ChannelElement = "Channel";
        public const string ArtistsElement = "Artists";
        public const string ArtistElement = "Artist";
        public const string TitleElement = "Title";
        public const string KindElement = "Kind";
        public const string AlbumElement = "Album";
        public const string YearElement = "Year";
        public const string GenresElement = "Genres";
        public const string GenreElement = "Genre";
        public const string TagsElement = "Tags";
        public const string TagElement = "Tag";
        public const string PhysicalPathElement = "PhysicalPath";
        public const string AudioBitrateElement = "AudioBitrate";
        public const string AudioChannelsElement = "AudioChannels";
        public const string AudioSampleRateElement = "AudioSampleRate";
        public const string DescriptionElement = "Description";
        public const string DurationElement = "Duration";
        public const string LCIDsElement = "LCIDs";
        public const string LCIDElement = "LCID";
        public const string CountryElement = "Country";
        public const string RenameToElement = "RenameTo";
        public const string MoodsElement = "Moods";
        public const string MoodElement = "Mood";
        #endregion

        private List<ITrackInfo> Read(XmlReader xml)
        {
            List<ITrackInfo> rslt = new List<ITrackInfo>();
            ITrackInfo currTrack = null;
            IArtistInfo currArtist = null;
            IMood currMood = null;
            IRadioChannel currChannel = null;
            IGenre currGenre = null;
            ITag currTag = null;

            XDocument document = XDocument.Load(xml);
            var left = from i in document.Descendants(TrackElement)
                       select new
                       {
                           Channels = i.Descendants(ChannelsElement).Count() > 0 ? from c in i.Descendants(ChannelsElement) select new { Channel = TakeValueIfNoNull( c.Element(ChannelElement)) } : null,
                           Artists = i.Descendants(ArtistsElement).Count() > 0 ? from a in i.Descendants(ArtistsElement) select new { Artist = TakeValueIfNoNull( a.Element(ArtistElement)) } : null,
                           Genres = i.Descendants(GenresElement).Count() > 0 ? from g in i.Descendants(GenresElement) select new { Genre = TakeValueIfNoNull(g.Element(GenreElement)) } : null,
                           Tags = i.Descendants(TagsElement).Count() > 0 ? from t in i.Descendants(TagsElement) select new { Tag = TakeValueIfNoNull(t.Element(TagElement))} : null,
                           LCIDs = i.Descendants(LCIDsElement).Count() > 0 ? from l in i.Descendants(LCIDsElement) select new { LCID = TakeValueIfNoNull(l.Element(LCIDElement))} : null,
                           Moods = i.Descendants(MoodsElement).Count() > 0 ? from m in i.Descendants(MoodsElement) select new { Mood = TakeValueIfNoNull(m.Element(MoodElement)) } : null,
                           Title = TakeValueIfNoNull(i.Element(TitleElement)),
                           Kind = TakeValueIfNoNull(i.Element(KindElement)),
                           Album = TakeValueIfNoNull(i.Element(AlbumElement)),
                           Year = TakeValueIfNoNull(i.Element(YearElement)),
                           PhysicalPath = TakeValueIfNoNull(i.Element(PhysicalPathElement)),
                           AudioBitrate = TakeValueIfNoNull(i.Element(AudioBitrateElement)),
                           AudioChannels = TakeValueIfNoNull(i.Element(AudioChannelsElement)),
                           AudioSampleRate = TakeValueIfNoNull(i.Element(AudioSampleRateElement)),
                           Description = TakeValueIfNoNull(i.Element(DescriptionElement)),
                           Duration = TakeValueIfNoNull(i.Element(DurationElement)),
                           Country = TakeValueIfNoNull(i.Element(CountryElement)),
                           RenameTo = TakeValueIfNoNull(i.Element(RenameToElement))
                       };
            if (left == null)
                return rslt;

            foreach (var trck in left)
            {
                currTrack = new tbl_track();
                currTrack.Album = trck.Album;
                currTrack.Artists = new List<IArtistInfo>();
                if(trck.Artists != null)
                {
                    foreach (var a in trck.Artists)
                        currTrack.Artists.Add(new tbl_artist() { artist_nm = a.Artist });
                }
                {
                    int tmp;
                    if (int.TryParse(trck.AudioChannels, out tmp))
                        currTrack.AudioChannels = tmp;
                }
                currTrack.AudioDescription = trck.Description;
                {
                    int tmp;
                    if (int.TryParse(trck.AudioSampleRate, out tmp))
                        currTrack.AudioSampleRate = tmp;
                }
                {
                    int tmp;
                    if (int.TryParse(trck.AudioBitrate, out tmp))
                        currTrack.Bitrate = tmp;
                }
                //currTrack.BPM = todo
                currTrack.Channels = new List<IRadioChannel>();
                if (trck.Channels != null)
                {
                    foreach (var c in trck.Channels)
                        currTrack.Channels.Add(new tbl_radio_stream() { stream_nm = c.Channel });
                }
                {
                    TimeSpan ts;
                    if (TimeSpan.TryParse(trck.Duration, out ts))
                        currTrack.Duration = ts;
                }

                currTrack.Genres = new List<IGenre>();
                if (trck.Genres != null)
                {
                    foreach (var g in trck.Genres)
                        currTrack.Genres.Add(new tbl_ref_music_genre() { genre_nm = g.Genre });
                }
                currTrack.Kind = (GenericDAL.Enums.TrackKind)Enum.Parse(typeof(GenericDAL.Enums.TrackKind), trck.Kind);
                currTrack.LCIDs = new List<int>();
                if (trck.LCIDs != null)
                {
                    foreach (var lcidStr in trck.LCIDs)
                    {
                        int lcid = CultureInfo.InvariantCulture.LCID;
                        try
                        {
                            CultureInfo ci = CultureInfo.GetCultureInfoByIetfLanguageTag(lcidStr.LCID);
                            if (ci != null)
                                lcid = ci.LCID;
                        }
                        catch (Exception) { }
                        currTrack.LCIDs.Add(lcid);
                    }
                }
                currTrack.Moods = new List<IMood>();
                if (trck.Moods != null)
                {
                    foreach (var m in trck.Moods)
                        currTrack.Moods.Add(new tbl_ref_music_mood() { mood_nm = m.Mood });
                }
                currTrack.PhysicalPath = trck.PhysicalPath;
                currTrack.RenameTo = trck.RenameTo;
                currTrack.Tags = new List<ITag>();
                if (trck.Tags != null)
                {
                    foreach (var tg in trck.Tags)
                        currTrack.Tags.Add(new tbl_tag() { tag_nm = tg.Tag });
                }

                currTrack.Title = trck.Title;
                {
                    int tmp;
                    if (int.TryParse(trck.Year, out tmp))
                        currTrack.Year = tmp;
                }
                rslt.Add(currTrack);
            }
            return rslt;
        }

        private string TakeValueIfNoNull(XElement xElement)
        {
            if (xElement == null)
                return null;
            return xElement.Value;
        }

        public bool Import(string path)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Auto;
            settings.CheckCharacters = false;
            settings.ValidationFlags = System.Xml.Schema.XmlSchemaValidationFlags.None;

            using (XmlReader r = XmlReader.Create(path, settings))
            {
                Tracks = Read(r);
                return true;
            }
        }

        public List<ITrackInfo> Tracks { get; private set; }
    }
}
