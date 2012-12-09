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
        int Title { get; set; }
        TrackKind Kind { get; set; }
        IList<IArtistInfo> Artists { get; set; }
        IList<IGenre> Genres { get; set; }
        IList<IMood> Moods { get; set; }
        IList<ITag> Tags { get; set; }
        int LCID { get; set; }
        string LanguageCode { get; }
        int BPM { get; set; }
        TimeSpan Duration { get; set; }
        string PhysicalPath { get; set; }
    }
}
