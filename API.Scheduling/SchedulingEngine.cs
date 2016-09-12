using System;

namespace API.Scheduling
{
    public class SchedulingEngine : ISchedulingEngine
    {
        private const int InterStopDelayInMinutes = 2;

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

        internal TimeSpan[] GetArrivalTimes(TimeSpan currentTime, int stopId, int routeId)
        {
            if (stopId >= StopCount)
            {
                throw new ArgumentException("Invalid stop ID", nameof(stopId));
            }

            if (routeId >= Routes.Length)
            {
                throw new ArgumentException("Invalid route ID", nameof(routeId));
            }

            var route = GetRoute(routeId);
            var routeStartTime = route.StartTimeOffset + StartTime;
            var stopOffset = TimeSpan.FromMinutes(InterStopDelayInMinutes * stopId);
            var stopTime = routeStartTime + stopOffset;
            while (stopTime < currentTime)
            {
                stopTime = stopTime.Add(TimeSpan.FromMinutes(15.0));
            }

            return new[]
            {
                stopTime,
                stopTime.Add(TimeSpan.FromMinutes(15))
            };
        }

        private Route GetRoute(int routeId) => Routes[routeId];
    }
}