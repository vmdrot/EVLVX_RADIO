using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.Core.DIServiceContracts
{
    public interface IPlayListFlusher
    {
        bool Flush(List<ITrackInfo> lst, string target);
    }
}
