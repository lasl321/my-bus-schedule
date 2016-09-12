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
            Routes = new[]
            {
                new Route("R1", TimeSpan.FromMinutes(0)),
                new Route("R2", TimeSpan.FromMinutes(2)),
                new Route("R3", TimeSpan.FromMinutes(4))
            };
        }

        public TimeSpan StartTime { get; }
        public Route[] Routes { get; set; }
    }
}