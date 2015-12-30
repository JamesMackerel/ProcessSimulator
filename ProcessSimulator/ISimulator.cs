using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSimulator
{
    interface ISimulator
    {
        IList<VirtualProcess> ProcessList { get; set; }
        bool IsPreemptive { get; set; }
    }
}
