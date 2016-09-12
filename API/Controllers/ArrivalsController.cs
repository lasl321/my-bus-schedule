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

        public ArrivalsController() : this(new SchedulingEngine())
        {
        }

        internal ArrivalsController(ISchedulingEngine engine)
        {
            _engine = engine;
        }

        public IEnumerable<TimeSpan[]> GetArrivals(int id)
        {
            var currentTime = DateTime.Now.TimeOfDay;
            var stopId = id;

            return Enumerable.Range(0, 3)
                             .Select(x => _engine.GetArrivalTimes(currentTime, stopId, x));
        }
    }
}