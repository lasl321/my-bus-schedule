using System;

namespace API.Scheduling
{
    public struct Route
    {
        public Route(string name, TimeSpan startTimeOffset)
        {
            Name = name;
            StartTimeOffset = startTimeOffset;
        }

        public string Name;
        public TimeSpan StartTimeOffset;
    }
}