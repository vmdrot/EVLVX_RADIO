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
        //protected int _lastTrackIndex = -1; //todo
        protected TimeSpan _cumulativeDuration = new TimeSpan(0, 0, 0, 0);
        protected List<ITrackInfo> _rslt;
        protected DateTime _airStart;
        protected DateTime _airEnd;
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
            int mainLCID = ti.LCID;
            int abstand = int.MaxValue;
            int localIndex = FindLastSameLCIDInCurrentList(mainLCID);
            if (localIndex != -1)
                abstand = _cumulativeLength - localIndex;
            else
                abstand = this._trackScheduleRetriever.GetLangAbstandTracks(mainLCID, this._airStart) + _cumulativeLength;
            return (abstand >= MinSameLCIDAbstand);
        }

        protected bool CheckSameTrackAbstand(ITrackInfo ti)
        {
            if (MinSameTrackAbstand <= 0)
                return true;
            int abstand = int.MaxValue;
            int localIndex = FindLastSameTrackInCurrentList(ti.ID);
            if (localIndex != -1)
                abstand = _cumulativeLength - localIndex;
            else
                abstand = this._trackScheduleRetriever.GetTrackAbstandTracks(ti.ID, this._airStart) + _cumulativeLength;
            return (abstand >= MinSameTrackAbstand);
        }


        protected bool CheckSameArtistAbstand(ITrackInfo ti)
        {
            if (MinSameArtistAbstand <= 0)
                return true;
            int mainArtist = ti.Artists[0].ID;
            int abstand = int.MaxValue;
            int localIndex = FindLastSameArtistInCurrentList(mainArtist);
            if (localIndex != -1)
                abstand = _cumulativeLength - localIndex;
            else
                abstand = this._trackScheduleRetriever.GetArtistAbstandTracks(mainArtist, this._airStart) + _cumulativeLength;
            return (abstand >= MinSameArtistAbstand);
        }

        private int FindLastSameArtistInCurrentList(int mainArtist)
        {
            int rslt = -1;
            for (int i = 0; i < this._rslt.Count; i++)
            {
                if (this._rslt[i].Artists[0].ID == mainArtist)
                    rslt = i;
            }
            return rslt;
        }

        private int FindLastSameTrackInCurrentList(int trackId)
        {
            int rslt = -1;
            for (int i = 0; i < this._rslt.Count; i++)
            {
                if (this._rslt[i].ID == trackId)
                    rslt = i;
            }
            return rslt;
        }

        private int FindLastSameLCIDInCurrentList(int lcid)
        {
            int rslt = -1;
            for (int i = 0; i < this._rslt.Count; i++)
            {
                if (this._rslt[i].LCID == lcid)
                    rslt = i;
            }
            return rslt;
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
