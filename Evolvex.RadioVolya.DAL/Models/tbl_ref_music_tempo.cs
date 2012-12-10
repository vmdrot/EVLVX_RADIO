using System;
using System.Collections.Generic;

namespace Evolvex.RadioVolya.DAL.Models
{
    public partial class tbl_ref_music_tempo
    {
        public int tempo_id { get; set; }
        public string tempo_nm { get; set; }
        public int bpm { get; set; }
    }
}
