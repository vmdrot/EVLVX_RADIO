using System;
using System.Collections.Generic;

namespace Evolvex.RadioVolya.DAL.Models
{
    public class tbl_track_play_history
    {
        public int trk_pl_hist_id { get; set; }
        public int track_id { get; set; }
        public int stream_id { get; set; }
        public System.DateTime play_dttm { get; set; }
    }
}
