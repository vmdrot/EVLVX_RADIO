using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.DAL.Models
{
    public partial class tbl_ref_music_mood : IMood
    {
        #region IMood Members

        public int ID
        {
            get
            {
                return this.mood_id;
            }
            set
            {
                this.mood_id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.mood_nm;
            }
            set
            {
                this.mood_nm = value;
            }
        }

        #endregion
    }
}
