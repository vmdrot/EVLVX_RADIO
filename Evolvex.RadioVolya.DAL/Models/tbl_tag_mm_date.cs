using System;
using System.Collections.Generic;

namespace Evolvex.RadioVolya.DAL.Models
{
    public class tbl_tag_mm_date
    {
        public int tag_dttm_id { get; set; }
        public int tag_id { get; set; }
        public System.DateTime start_dttm { get; set; }
        public System.DateTime end_dttm { get; set; }
    }
}
