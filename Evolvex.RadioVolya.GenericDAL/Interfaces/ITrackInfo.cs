using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.GenericDAL.Enums;

namespace Evolvex.RadioVolya.GenericDAL.Interfaces
{
    public interface ITrackInfo
    {
        int ID { get; set; }
        String Title { get; set; }
        String Album { get; set; }
        int Year { get; set; }
        TrackKind Kind { get; set; }
        IList<IArtistInfo> Artists { get; set; }
        IList<IGenre> Genres { get; set; }
        IList<IMood> Moods { get; set; }
        IList<ITag> Tags { get; set; }
        IList<IRadioChannel> Channels { get; set; }
        IList<int> LCIDs { get; set; }
        int LCID { get; }
        IList<string> LanguageCodes { get; }
        string LanguageCode { get; }
        int BPM { get; set; }
        TimeSpan Duration { get; set; }
        int Bitrate { get; set; }
        int AudioChannels { get; set; }
        int AudioSampleRate { get; set; }
        string AudioDescription { get; set; }
        string PhysicalPath { get; set; }
        string RenameTo { get; set; }
    }
}
