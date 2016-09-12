using System;

namespace API.Scheduling
{
    public class SchedulingEngine : ISchedulingEngine
    {
        public SchedulingEngine() : this(TimeSpan.Zero)
        {
        }

        internal SchedulingEngine(TimeSpan startTime)
        {
            StartTime = startTime;
        }

        public TimeSpan StartTime { get; }
    }
}