using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.RadioVolya.GenericDAL.Interfaces
{
    public interface ITrackInfo
    {
        int ID { get; set; }
        int Title { get; set; }
        IList<IArtistInfo> Artists { get; set; }
        IList<IGenre> Genres { get; set; }


    }
}
