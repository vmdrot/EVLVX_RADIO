using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.DAL.Models
{
    public partial class tbl_ref_music_genre : IGenre
    {
        #region IGenre Members

        public int ID
        {
            get
            {
                return this.genre_id;
            }
            set
            {
                this.genre_id = value;
            }
        }

        public int? ParentID
        {
            get
            {
                return null;
            }
            set
            {
                
            }
        }

        public string Name
        {
            get
            {
                return this.genre_nm;
            }
            set
            {
                this.genre_nm = value;
            }
        }

        #endregion
    }
}
