using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.MediaContentScheduler
{
    public class PlaylistGenerator
    {
        #region field(s)
        private int _channelId;
        private IRandomTrackDispenser _dispenser;

        #endregion
        public PlaylistGenerator(IUnityContainer cont)
        {

        }

        public PlaylistGenerator(int channelId, DateTime airStart, DateTime airEnd)
        {

        }
    }
}
