using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.RadioVolya.MediaContentScheduler
{
    public class RandomTrackDispenser
    {
        #region field(s)
        private int _channelId;
        private List<int> _alreadyTried;
        #endregion

        #region cctor(s)
        public RandomTrackDispenser(int channelId)
        {
            this._channelId = channelId;
            this._alreadyTried = new List<int>();
        }
        #endregion

        private int GenerateRandomID()
        {
            return 0;//todo;
        }
        public int Next()
        {
            int rslt = 0;
            do
            {
                rslt = GenerateRandomID();
            } while (_alreadyTried.Contains(rslt));
            _alreadyTried.Add(rslt);
            return rslt;
        }
    }
}
