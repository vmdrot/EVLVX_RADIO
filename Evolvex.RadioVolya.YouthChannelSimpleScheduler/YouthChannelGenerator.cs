using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.Core.DIServiceContracts;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.YouthChannelSimpleScheduler
{
    public class YouthChannelGenerator: IPlaylistGenerator
    {
        #region IPlaylistGenerator Members

        public List<ITrackInfo> Generate()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
