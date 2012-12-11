using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evolvex.RadioVolya.GenericDAL.Interfaces
{
    public interface IRadioChannel
    {
        int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
