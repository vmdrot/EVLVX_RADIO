using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.RadioVolya.GenericDAL.Interfaces
{
    public interface ITag
    {
        int ID { get; set; }
        String Code { get; set; }
        String Name { get; set; }
    }
}
