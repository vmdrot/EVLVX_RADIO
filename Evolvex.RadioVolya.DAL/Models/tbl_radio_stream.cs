using System;
using System.Collections.Generic;

namespace Evolvex.RadioVolya.DAL.Models
{
    public class tbl_radio_stream
    {
        public int stream_id { get; set; }
        public string stream_nm { get; set; }
        public string stream_url { get; set; }
        public string stream_descr { get; set; }
    }
}
