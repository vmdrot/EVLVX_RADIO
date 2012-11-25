using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Evolvex.RadioVolya.GenericDAL.Interfaces;
using Evolvex.RadioVolya.Core.DIServiceContracts;

namespace Evolvex.RadioVolya.MediaContentScheduler
{
    public class PlaylistGenerator
    {
        #region field(s)
        private int _channelId;
        private IRandomTrackDispenser _dispenser;
        private IPlayListGenerationParams _params;
        private ITrackInfoRetriever _trackInfoRetriever;
        private IPlayListRulesChecker _rulesChecker;
        private List<ITrackInfo> _result;
        #endregion

        #region cctor(s)
        public PlaylistGenerator(IUnityContainer cont)
        {
            _dispenser = cont.Resolve<IRandomTrackDispenser>();
            _params = cont.Resolve<IPlayListGenerationParams>();
            _trackInfoRetriever = cont.Resolve<ITrackInfoRetriever>();
            _rulesChecker = cont.Resolve<IPlayListRulesChecker>();
        }

        //public PlaylistGenerator(int channelId, DateTime airStart, DateTime airEnd)
        //{

        //}
        #endregion

        #region method(s)
        public List<ITrackInfo> Generate()
        {
            DateTime currentProgress = _params.AirStart;
            while (currentProgress < _params.AirEnd)
            {
                ITrackInfo track = PickUpNextTrack();
                currentProgress += new TimeSpan(0, 0, track.Duration);
                _result.Add(track);
            }
            return _result;
        }

        private ITrackInfo PickUpNextTrack()
        {
            ITrackInfo rslt = null;
            do
            {
                int trackId = _dispenser.Next();
                rslt = _trackInfoRetriever.GetById(trackId);
                if (_rulesChecker.Check(rslt, _result))
                    break;
            } while (true);
            return rslt;
        }
        #endregion

    }
}
