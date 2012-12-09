using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.Core.DIServiceContracts;
using System.IO;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.YouthChannelSimpleScheduler.Impls.Flushers
{
    public class IceCastPlaylistFlusher: IPlayListFlusher
    {
        #region IPlayListFlusher Members

        public bool Flush(List<GenericDAL.Interfaces.ITrackInfo> lst, string target)
        {
            bool rslt = false;
            using (StreamWriter sw = new StreamWriter(target))
            {
                foreach (ITrackInfo ti in lst)
                {
                    sw.WriteLine(ti.PhysicalPath);
                }
            }
            return rslt;
        }

        #endregion
    }
}
