using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.Core.DIServiceContracts;

namespace Evolvex.RadioVolya.YouthChannelSimpleScheduler.Impls.Basic
{
    public class RandomTracksGeneratorBase : IPlaylistGenerator
    {

        #region prop(s)
        public int? Length { get; set; }
        public TimeSpan? Duration { get; set; }
        public int MinSameArtistAbstand { get; set; }
        public int MinSameTrackAbstand { get; set; }
        public int MinSameLCIDAbstand { get; set; }
        #endregion



        #region IPlaylistGenerator Members

        public List<GenericDAL.Interfaces.ITrackInfo> Generate()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
