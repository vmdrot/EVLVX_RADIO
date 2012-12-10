using System;
using System.Collections.Generic;

namespace Evolvex.RadioVolya.DAL.Models
{
    public partial class tbl_schedule_rule
    {
        public int rule_id { get; set; }
        public int stream_id { get; set; }
        public int block_id { get; set; }
        public string rule_def { get; set; }
        public Nullable<System.DateTime> valid_since { get; set; }
        public Nullable<System.DateTime> valid_till { get; set; }
        public Nullable<bool> is_enabled { get; set; }
    }
}
