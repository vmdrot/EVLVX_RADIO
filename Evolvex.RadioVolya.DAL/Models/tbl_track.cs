using System;
using System.Collections.Generic;

namespace Evolvex.RadioVolya.DAL.Models
{
    public partial class tbl_track
    {
        public int track_id { get; set; }
        public string track_nm { get; set; }
        public string album_nm { get; set; }
        public string file_path { get; set; }
        public Nullable<int> bitrate { get; set; }
        public Nullable<int> file_size { get; set; }
        public Nullable<int> release_year { get; set; }
        public Nullable<int> duration { get; set; }
        public Nullable<int> bpm { get; set; }
        public string lyrics { get; set; }
    }
}
