using System;

namespace API.Scheduling
{
    public struct Route
    {
        public Route(int id, TimeSpan startTimeOffset)
        {
            _id = id;
            StartTimeOffset = startTimeOffset;
        }

        private readonly int _id;
        public TimeSpan StartTimeOffset;
    }
}