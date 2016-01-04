using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSimulator
{
    public struct SchedulingAlgorithm
    {
        private string algorithm;
        private string describtion;

        public string Algorithm
        {
            get
            {
                return algorithm;
            }

            set
            {
                algorithm = value;
            }
        }

        public string Describtion
        {
            get
            {
                return describtion;
            }

            set
            {
                describtion = value;
            }
        }

        public SchedulingAlgorithm(string algorithm, string describtion)
        {
            this.algorithm = algorithm;
            this.describtion = describtion;
        }
    }

    class SimulatorFactory
    {
        private static List<SchedulingAlgorithm> supportedAlgorithm;

        static SimulatorFactory()
        {
            supportedAlgorithm = new List<SchedulingAlgorithm>();
            supportedAlgorithm.Add(new SchedulingAlgorithm("FCFS", "FCFS (First Come First Serve)"));
        }

        public static List<SchedulingAlgorithm> SupportedAlgorithm
        {
            get
            {
                return supportedAlgorithm;
            }
        }

        public ISimulator getSimulator(SchedulingAlgorithm algorithm, bool isPreemptive)
        {
            ISimulator simulator = null;
            switch (algorithm.Algorithm)
            {
                case "FCFS":
                    simulator = new FcfsSimulator();
                    break;

                default:
                    throw new Exception(string.Format("{0} is not supported.", algorithm.Algorithm));
            }

            return simulator;
        }
    }

}
