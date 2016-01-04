using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSimulator
{
    interface ISimulator
    {
        void Simulate(List<VirtualProcess> processes);
    }
}
