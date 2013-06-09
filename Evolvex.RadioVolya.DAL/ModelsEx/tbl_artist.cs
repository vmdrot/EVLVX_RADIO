using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.DAL.Models
{
    public partial class tbl_artist: IArtistInfo
    {

        #region IArtistInfo Members

        public int ID
        {
            get
            {
                return this.artist_id;
            }
            set
            {
                this.artist_id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.artist_nm;
            }
            set
            {
                this.artist_nm = value;
            }
        }

        public string Country {get;set;}
        

        #endregion
    }
}
