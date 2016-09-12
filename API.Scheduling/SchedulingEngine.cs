using System;

namespace API.Scheduling
{
    public class SchedulingEngine : ISchedulingEngine
    {
        private static readonly Route[] DefaultRoutes =
        {
            new Route("R1", TimeSpan.FromMinutes(0)),
            new Route("R2", TimeSpan.FromMinutes(2)),
            new Route("R3", TimeSpan.FromMinutes(4))
        };

        public SchedulingEngine() : this(TimeSpan.Zero, 10, DefaultRoutes)
        {
        }

        internal SchedulingEngine(TimeSpan startTime, int stopCount, Route[] routes)
        {
            StopCount = stopCount;
            StartTime = startTime;
            Routes = routes;
        }

        public TimeSpan StartTime { get; }
        public Route[] Routes { get; set; }
        public int StopCount { get; }

        internal DateTime[] GetArrivalTimes(DateTime currentTime, int stopId, int routeId)
        {
            throw new NotImplementedException();
        }
    }
}