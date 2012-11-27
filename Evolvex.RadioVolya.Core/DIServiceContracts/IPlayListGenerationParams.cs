using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.RadioVolya.Core.DIServiceContracts
{
    public interface IPlayListGenerationParams
    {
        int ChannelID { get; }
        DateTime AirStart { get; }
        DateTime AirEnd { get; }
    }
}
