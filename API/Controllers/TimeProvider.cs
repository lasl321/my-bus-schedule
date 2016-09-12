using System;

namespace API.Controllers
{
    internal class TimeProvider : ITimeProvider
    {
        public TimeProvider() : this(DateTime.Now.TimeOfDay)
        {
        }

        internal TimeProvider(TimeSpan currentTime)
        {
            CurrentTime = currentTime;
        }

        public TimeSpan CurrentTime { get; }
    }
}