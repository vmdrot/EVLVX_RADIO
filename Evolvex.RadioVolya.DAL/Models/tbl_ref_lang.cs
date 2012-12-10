using System;
using System.Collections.Generic;

namespace Evolvex.RadioVolya.DAL.Models
{
    public partial class tbl_ref_lang
    {
        public int lcid { get; set; }
        public string ietf_tag { get; set; }
        public string eng_nm { get; set; }
        public string ukr_nm { get; set; }
    }
}
