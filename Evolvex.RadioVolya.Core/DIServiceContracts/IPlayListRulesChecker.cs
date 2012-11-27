using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.Core.DIServiceContracts
{
    public interface IPlayListRulesChecker
    {
        bool Check(ITrackInfo track, List<ITrackInfo> previousPlaylist);
    }
}
