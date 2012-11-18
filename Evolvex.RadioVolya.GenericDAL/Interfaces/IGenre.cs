using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.RadioVolya.GenericDAL.Interfaces
{
    public interface IGenre
    {
        int ID { get; set; }
        int? ParentID { get; set; }
        string Name { get; set; }
    }
}
