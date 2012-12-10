using System;
using System.Collections.Generic;

namespace Evolvex.RadioVolya.DAL.Models
{
    public partial class tbl_artist
    {
        public int artist_id { get; set; }
        public string artist_nm { get; set; }
        public Nullable<int> country_id { get; set; }
        public Nullable<System.DateTime> birth_dttm { get; set; }
        public Nullable<System.DateTime> departed_dttm { get; set; }
        public string notes { get; set; }
    }
}
