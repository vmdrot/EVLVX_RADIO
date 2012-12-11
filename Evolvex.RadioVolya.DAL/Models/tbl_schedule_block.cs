using System;
using System.Collections.Generic;

namespace Evolvex.RadioVolya.DAL.Models
{
    public class tbl_schedule_block
    {
        public int block_id { get; set; }
        public string block_nm { get; set; }
        public System.DateTime start_time { get; set; }
        public System.DateTime end_time { get; set; }
    }
}
