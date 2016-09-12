using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Scheduling;

namespace API.Controllers
{
    public class ArrivalsController : ApiController
    {
        private readonly ISchedulingEngine _engine;
        private readonly ITimeProvider _timeProvider;

        public ArrivalsController() : this(new SchedulingEngine(), new TimeProvider())
        {
        }

        internal ArrivalsController(ISchedulingEngine engine, ITimeProvider timeProvider)
        {
            _engine = engine;
            _timeProvider = timeProvider;
        }

        public IEnumerable<TimeSpan[]> GetArrivals(int id)
        {
            var currentTime = _timeProvider.CurrentTime;
            var stopId = id;

            return Enumerable.Range(0, 3)
                             .Select(x => _engine.GetArrivalTimes(currentTime, stopId, x));
        }
    }
}