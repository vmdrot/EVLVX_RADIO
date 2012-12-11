using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.DAL.Models
{
    public partial class tbl_track: ITrackInfo
    {

        #region ITrackInfo Members

        public int ID
        {
            get
            {
                return this.track_id;
            }
            set
            {
                this.track_id = value;
            }
        }

        public string Title
        {
            get
            {
                return this.track_nm;
            }
            set
            {
                this.track_nm = value;
            }
        }

        public GenericDAL.Enums.TrackKind Kind
        {
            get
            {
                return (Evolvex.RadioVolya.GenericDAL.Enums.TrackKind)this.track_kind_id;
            }
            set
            {
                this.track_kind_id = (int)value;
            }
        }
        
        public IList<IArtistInfo> Artists
        {
            get
            {
                return null; //todo
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<IGenre> Genres
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<IMood> Moods
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<ITag> Tags
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IList<IRadioChannel> Channels
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int LCID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string LanguageCode
        {
            get { throw new NotImplementedException(); }
        }

        public int BPM
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public TimeSpan Duration
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string PhysicalPath
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
