using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.Core.DIServiceContracts;
using Microsoft.Practices.Unity;

namespace Evolvex.RadioVolya.YouthChannelSimpleScheduler.Impls.Basic
{
    class DefaultRandomTrackDispenser : IRandomTrackDispenser
    {
        #region field(s)
        private IPlayListGenerationParams _params;
        private int _channelId;
        private List<int> _alreadyTried;
        private List<int> _wholePopulation;
        private ITrackPopulationLister _trackPopulationLister;
        private Random _rnd;
        #endregion

        #region prop(s)
        private List<int> AvailableTrackIDs
        {
            get
            {
                if (this._wholePopulation == null)
                    this._wholePopulation = this._trackPopulationLister.List(this._params.ChannelID);
                return this._wholePopulation;
            }
        }
        #endregion
        #region cctor(s)
        public DefaultRandomTrackDispenser(IUnityContainer cont)
        {
            _params = cont.Resolve<IPlayListGenerationParams>();
            _trackPopulationLister = cont.Resolve<ITrackPopulationLister>();
            this._alreadyTried = new List<int>();
            this._wholePopulation = _trackPopulationLister.List(this._params.ChannelID);
            this._rnd = new Random();
        }
        #endregion

        private int GenerateRandomID()
        {
            int idx = this._rnd.Next(this.AvailableTrackIDs.Count - 1);
            return this.AvailableTrackIDs[idx];
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
