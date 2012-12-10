using System;
using System.Collections.Generic;

namespace Evolvex.RadioVolya.DAL.Models
{
    public class tbl_track_schedule
    {
        public int trk_schdl_id { get; set; }
        public int track_id { get; set; }
        public int stream_id { get; set; }
        public System.DateTime scheduled_play_dttm { get; set; }
    }
}
