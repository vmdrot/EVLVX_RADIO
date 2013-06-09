using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Evolvex.RadioVolya.GenericDAL.Interfaces;

namespace Evolvex.RadioVolya.DAL.Models
{
    public partial class tbl_radio_stream : IRadioChannel
    {

        #region IRadioChannel Members

        public int ID
        {
            get
            {
                return this.stream_id;
            }
            set
            {
                this.stream_id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.stream_nm;
            }
            set
            {
                this.stream_nm = value;
            }
        }

        public string Description
        {
            get
            {
                return this.stream_descr;
            }
            set
            {
                this.stream_descr = value;
            }
        }

        #endregion
    }
}
