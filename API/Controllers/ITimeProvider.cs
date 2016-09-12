using System;

namespace API.Controllers
{
    internal interface ITimeProvider
    {
        TimeSpan CurrentTime { get; }
    }
}