using System;
using System.Collections.Generic;

namespace Evolvex.RadioVolya.DAL.Models
{
    public class tbl_track_mm_stream
    {
        public int track_stream_id { get; set; }
        public int stream_id { get; set; }
        public int track_id { get; set; }
        public System.DateTime assigned_dttm { get; set; }
    }
}
