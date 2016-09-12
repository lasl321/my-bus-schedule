using System;

namespace API.Scheduling
{
    public interface ISchedulingEngine
    {
        TimeSpan[] GetArrivalTimes(TimeSpan currentTime, int stopId, int routeId);
    }
}