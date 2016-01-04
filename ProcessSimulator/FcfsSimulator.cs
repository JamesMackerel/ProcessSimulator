using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSimulator
{
    class FcfsSimulator : ISimulator
    {
        public void Simulate(List<VirtualProcess> processes)
        {
            processes.Sort(delegate (VirtualProcess p1, VirtualProcess p2)
            {
                return p1.ArriveTime.CompareTo(p2.ArriveTime);
            });

            Queue<VirtualProcess> WaitingQueue = new Queue<VirtualProcess>(processes); //all process are in the queue, no matter they had arrived or not.
            VirtualProcess RunningProcess = WaitingQueue.Dequeue(); //the porcess that is running now
            DateTime now = WaitingQueue.Peek().ArriveTime; //set now to the first task's arrive time
            RunningProcess.StartTime = RunningProcess.ArriveTime;

            processes.RemoveAll(x => true);

            while(RunningProcess!=null || (RunningProcess == null && WaitingQueue.Count == 0))
            {
                //if the task is done, save it to the processes list, and get next process
                if ((now - RunningProcess.StartTime) == RunningProcess.Duration)
                {
                    RunningProcess.CompleteTime = now;
                    processes.Add(RunningProcess);
                    RunningProcess = null;
                }
                if (RunningProcess == null && WaitingQueue.Peek().ArriveTime >= now)
                {
                    RunningProcess = WaitingQueue.Dequeue();
                    RunningProcess.StartTime = now;
                }
                now.AddMinutes(1.0);
            }
        }
    }
}
