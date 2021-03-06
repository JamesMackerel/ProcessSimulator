﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessSimulator
{
    class VirtualProcess
    {
        #region user control attribute
        public int Pid {set; get; }
        public int Priority { set; get; }
        public DateTime ArriveTime { set; get; }
        public TimeSpan Duration { set; get; }
        #endregion

        #region non user control attribute
        public DateTime? StartTime { set; get; }
        public DateTime? CompleteTime { set; get; }
        #endregion

        public VirtualProcess(int pid, int priority, TimeSpan duration, DateTime arrivetime)
        {
            this.Pid = pid;
            this.Priority = priority;
            this.Duration = duration;
            this.ArriveTime = arrivetime;

            StartTime = null;
            CompleteTime = null;
        }
    }
}
