using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.DAL.Models
{
    public partial class tbl_tag : ITag
    {
        #region ITag Members

        public int ID
        {
            get
            {
                return this.tag_id;
            }
            set
            {
                this.tag_id = value;
            }
        }

        public string Code
        {
            get
            {
                return this.tag_cd;
            }
            set
            {
                this.tag_cd = value;
            }
        }

        public string Name
        {
            get
            {
                return this.tag_nm;
            }
            set
            {
                this.tag_nm = value;
            }
        }

        #endregion
    }
}
