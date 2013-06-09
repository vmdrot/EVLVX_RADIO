using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.GenericDAL.Interfaces;
using System.Xml;
using Evolvex.RadioVolya.DAL.Models;
using System.Globalization;

namespace Evolvex.RadioVolya.DAL.Import
{
    public class XmlImporter
    {

        #region const(s)
        public const string TracksElement = "Tracks";
        public const string TrackElement = "Track";
        public const string ChannelsElement = "Channels";
        public const string ChannelElement = "Channel";
        public const string ArtistsElement = "Artists";
        public const string ArtistElement = "Artist";
        public const string TitleElement = "Title";
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
            //
            string lastTagName = null;
            bool bExit = false;
            while (xml.Read())
            {
                
                switch (xml.NodeType)
                {
                    case XmlNodeType.Element:
                        lastTagName = xml.Value;
                        #region construct new object
                        switch (xml.Value)
                        { 
                            case ChannelsElement:
                                currTrack.Channels = new List<IRadioChannel>();
                                break;
                            case ArtistsElement:
                                currTrack.Artists = new List<IArtistInfo>();
                                break;
                            case GenresElement:
                                currTrack.Genres = new List<IGenre>();
                                break;
                            case TagsElement:
                                currTrack.Tags = new List<ITag>();
                                break;
                            case LCIDsElement:
                                currTrack.LCIDs = new List<int>();
                                break;
                            case ChannelElement:
                                currChannel = new tbl_radio_stream();
                                break;
                            case ArtistElement:
                                currArtist = new tbl_artist();
                                break;
                            case GenreElement:
                                currGenre = new tbl_ref_music_genre();
                                break;

                            case TagElement:
                                currTag = new tbl_tag();
                                break;

                        }
                        #endregion
                        break;
                    case XmlNodeType.EndElement:
                        {
                            #region handling end element
                            switch (xml.Value)
                            {
                                case TracksElement: 
                                    bExit = true;
                                    break;
                                case TrackElement:
                                    rslt.Add(currTrack);
                                    currTrack = null;
                                    break;
                                    //Channels
                                case ChannelElement:
                                    currTrack.Channels.Add(currChannel);
                                    currChannel = null;
                                    break;
                                //case ArtistsElement:
                                case ArtistElement:
                                    currTrack.Artists.Add(currArtist);
                                    currArtist = null;
                                    break;
                                //Genres
                                case GenreElement:
                                    currTrack.Genres.Add(currGenre);
                                    currGenre = null;
                                    break;
                                //case TagsElement:
                                case TagElement:
                                    currTrack.Tags.Add(currTag);
                                    currTag = null;
                                    break;
                                //LCIDs
                                case LCIDElement:
                                    break;
                                case MoodElement:
                                    currTrack.Moods.Add(currMood);
                                    currMood = null;
                                    break;
                                default:
                                    break;
                            }
                            #endregion
                        }
                        break;
                    case XmlNodeType.Attribute:
                        break;
                    case XmlNodeType.CDATA:
                        break;
                    case XmlNodeType.Comment:
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentFragment:
                        break;
                    case XmlNodeType.DocumentType:
                        break;
                    case XmlNodeType.EndEntity:
                        break;
                    case XmlNodeType.Entity:
                        break;
                    case XmlNodeType.EntityReference:
                        break;
                    case XmlNodeType.None:
                        break;
                    case XmlNodeType.Notation:
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        break;
                    case XmlNodeType.SignificantWhitespace:
                        break;
                    case XmlNodeType.Text:
                        #region read scalar value(s)
                        {
                            switch (lastTagName)
                            { 
                                case ChannelElement:
                                    currChannel.Name = xml.Value;
                                    break;
                                case ArtistElement:
                                    currArtist.Name = xml.Value;
                                    break;
                                case TitleElement:
                                    currTrack.Title = xml.Value;
                                    break;
                                case AlbumElement:
                                    currTrack.Album = xml.Value;
                                    break;
                                case YearElement:
                                    {
                                        int tmp;
                                        if (int.TryParse(xml.Value, out tmp))
                                            currTrack.Year = tmp;
                                    }
                                    break;
                                case GenreElement:
                                    currGenre.Name = xml.Value;
                                    break;
                                case TagElement:
                                    currTag.Name = xml.Value;
                                    break;
                                case PhysicalPathElement:
                                    currTrack.PhysicalPath = xml.Value;
                                    break;
                                case AudioBitrateElement:
                                    {
                                        int tmp;
                                        if (int.TryParse(xml.Value, out tmp))
                                            currTrack.Bitrate = tmp;
                                    }
                                    break;
                                case AudioChannelsElement:
                                    {
                                        int tmp;
                                        if (int.TryParse(xml.Value, out tmp))
                                            currTrack.AudioChannels = tmp;
                                    }
                                    break;
                                case AudioSampleRateElement:
                                    {
                                        int tmp;
                                        if (int.TryParse(xml.Value, out tmp))
                                            currTrack.AudioSampleRate = tmp;
                                    }
                                    break;
                                case DescriptionElement:
                                    currTrack.AudioDescription = xml.Value;
                                    break;
                                case DurationElement:
                                    {
                                        TimeSpan ts;
                                        if(TimeSpan.TryParse(xml.Value, out ts))
                                            currTrack.Duration = ts;
                                    }
                                    break;
                                case LCIDElement:
                                    {
                                        int lcid = CultureInfo.InvariantCulture.LCID;
                                        try
                                        {
                                            CultureInfo ci = CultureInfo.GetCultureInfoByIetfLanguageTag(xml.Value);
                                            if (ci != null)
                                                lcid = ci.LCID;
                                        }
                                        catch(Exception ) {}
                                        currTrack.LCIDs.Add(lcid);
                                    }
                                    break;
                                case CountryElement:
                                    currArtist.Country = xml.Value;
                                    break;
                                case RenameToElement:
                                    currTrack.RenameTo = xml.Value;
                                    break;
                            }
                        }
                        #endregion
                        break;
                    case XmlNodeType.Whitespace:
                        break;
                    case XmlNodeType.XmlDeclaration:
                        break;
                    default:
                        break;
                }
                if (bExit)
                    break;
            }
            return rslt;
        }

        public ITrackInfo ReadTrack(XmlReader xml)
        {
            ITrackInfo rslt = null;
            string currElement = string.Empty;
            while (xml.Read())
            {
                switch (xml.NodeType)
                {
                    case XmlNodeType.Element:
                        currElement = xml.Name;
                        break;
                    case XmlNodeType.EndElement:
                        if (xml.Name == "Track")
                            return rslt;
                        break;
                    case XmlNodeType.Text:
                        {
                            switch (currElement)
                            {
                                case "Channels":
                                    rslt.Channels = null;//todo
                                    break;
                            }
                        }
                        break;

                    case XmlNodeType.Attribute:
                        break;
                    case XmlNodeType.CDATA:
                        break;
                    case XmlNodeType.Comment:
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentFragment:
                        break;
                    case XmlNodeType.DocumentType:
                        break;
                    case XmlNodeType.EndEntity:
                        break;
                    case XmlNodeType.Entity:
                        break;
                    case XmlNodeType.EntityReference:
                        break;
                    case XmlNodeType.None:
                        break;
                    case XmlNodeType.Notation:
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        break;
                    case XmlNodeType.SignificantWhitespace:
                        break;
                    case XmlNodeType.Whitespace:
                        break;
                    case XmlNodeType.XmlDeclaration:
                        break;
                    default:
                        break;
                }
            }
            return rslt;
        }
        public bool Import(string path)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Auto;
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
