using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.Core.DIServiceContracts;
using Evolvex.RadioVolya.GenericDAL.Interfaces;
using Microsoft.Practices.Unity;

namespace Evolvex.RadioVolya.YouthChannelSimpleScheduler.Impls.Basic
{
    public class RandomTracksGeneratorBase : IPlaylistGenerator
    {

        #region
        protected IRandomTrackDispenser _dispenser;
        protected ITrackInfoRetriever _trackRetriever;
        protected ITrackScheduleRetriever _trackScheduleRetriever;
        protected int _cumulativeLength = 0;
        protected TimeSpan _cumulativeDuration = new TimeSpan(0, 0, 0, 0);
        protected List<ITrackInfo> _rslt;
        #endregion

        #region cctor(s)
        public RandomTracksGeneratorBase(IUnityContainer cont)
        {
            this._trackRetriever = cont.Resolve<ITrackInfoRetriever>();
            this._dispenser = cont.Resolve<IRandomTrackDispenser>();
            this._trackScheduleRetriever = cont.Resolve<ITrackScheduleRetriever>();
        }
        #endregion

        #region prop(s)
        public int? RequiredLength { get; set; }
        public TimeSpan? RequiredDuration { get; set; }
        public int MinSameArtistAbstand { get; set; }
        public int MinSameTrackAbstand { get; set; }
        public int MinSameLCIDAbstand { get; set; }

        #endregion

        #region method(s)

        public List<GenericDAL.Interfaces.ITrackInfo> Generate()
        {
            _rslt = new List<ITrackInfo>();
            while (!IsDone())
            {
                int currId = _dispenser.Next();
                ITrackInfo ti = _trackRetriever.GetById(currId);
                if (CheckRules(ti))
                {
                    _rslt.Add(ti);
                    _cumulativeLength++;
                    _cumulativeDuration += ti.Duration;
                }

            }
            return _rslt;
        }

        private bool CheckRules(ITrackInfo ti)
        {
            if (!CheckSameArtistAbstand(ti))
                return false;
            if (!CheckSameTrackAbstand(ti))
                return false;
            if (!CheckSameLocaleAbstand(ti))
                return false;
            return true;
        }

        protected bool CheckSameLocaleAbstand(ITrackInfo ti)
        {
            if (MinSameLCIDAbstand <= 0)
                return true;
            throw new NotImplementedException();
        }

        protected bool CheckSameTrackAbstand(ITrackInfo ti)
        {
            if (MinSameTrackAbstand <= 0)
                return true;
            throw new NotImplementedException();
        }

        protected bool CheckSameArtistAbstand(ITrackInfo ti)
        {
            if (MinSameArtistAbstand <= 0)
                return true;
            throw new NotImplementedException();
        }

        protected bool IsDone()
        {
            if (RequiredLength != null)
                return CheckIfLengthIsEnough();
            else if (RequiredDuration != null)
                return CheckIfDurationIsEnough();
            else
                throw new ArgumentException("Please set either RequiredLength or RequiredDuration property value");
        }

        protected bool CheckIfDurationIsEnough()
        {
            if (RequiredDuration == null)
                return false;
            return (TimeSpan)RequiredDuration <= _cumulativeDuration;
        }

        protected bool CheckIfLengthIsEnough()
        {
            if (RequiredLength == null)
                return false;
            return (int)RequiredLength <= _cumulativeLength;
        }


        #endregion
    }
}
