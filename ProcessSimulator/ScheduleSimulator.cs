using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSimulator
{
    public struct SchedulingAlgorithm
    {
        string Algorithm;
        string Describtion;
    }

    class ScheduleSimulator
    {
        IList<VirtualProcess> processList;
        bool isPreemptive;


        internal IList<VirtualProcess> ProcessList
        {
            get
            {
                return processList;
            }

            set
            {
                processList = value;
            }
        }

        public bool IsPreemptive
        {
            get
            {
                return isPreemptive;
            }

            set
            {
                isPreemptive = value;
            }
        }

    }
}
