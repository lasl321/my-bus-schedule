using System;
using NUnit.Framework;

namespace API.Scheduling.Test.Unit
{
    public class Tests
    {
        private SchedulingEngine _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new SchedulingEngine();
        }

        [Test]
        public void ShouldStartScheduleAtMidnight()
        {
            var startTime = _sut.StartTime;
            Assert.That(startTime, Is.EqualTo(new TimeSpan(0, 0, 0)));
        }

        [Test]
        public void ShouldHave3Routes()
        {
            var count = _sut.Routes.Length;
            Assert.That(count, Is.EqualTo(3));
        }

        [Test]
        public void ShouldHave10Stops()
        {
            var count = _sut.StopCount;
            Assert.That(count, Is.EqualTo(10));
        }

        [TestCase("00:00:00", 0, 0, "00:00:00", "00:15:00")]
        [TestCase("00:00:00", 0, 1, "00:02:00", "00:17:00")]
        [TestCase("00:00:00", 0, 2, "00:04:00", "00:19:00")]
        [TestCase("00:00:00", 1, 0, "00:02:00", "00:17:00")]
        [TestCase("00:00:00", 1, 1, "00:04:00", "00:19:00")]
        [TestCase("00:00:00", 1, 2, "00:06:00", "00:21:00")]
        [TestCase("00:00:00", 2, 0, "00:04:00", "00:19:00")]
        [TestCase("00:00:00", 2, 1, "00:06:00", "00:21:00")]
        [TestCase("00:00:00", 2, 2, "00:08:00", "00:23:00")]
        [TestCase("00:03:00", 0, 0, "00:15:00", "00:30:00")]
        [TestCase("00:03:00", 0, 1, "00:17:00", "00:32:00")]
        [TestCase("00:03:00", 0, 2, "00:04:00", "00:19:00")]
        [TestCase("00:03:00", 1, 0, "00:17:00", "00:32:00")]
        [TestCase("00:03:00", 1, 1, "00:04:00", "00:19:00")]
        [TestCase("00:03:00", 1, 2, "00:06:00", "00:21:00")]
        [TestCase("00:03:00", 2, 0, "00:04:00", "00:19:00")]
        [TestCase("00:03:00", 2, 1, "00:06:00", "00:21:00")]
        [TestCase("00:03:00", 2, 2, "00:08:00", "00:23:00")]
        public void ShouldGetArrivalTimes(string currentTime,
                                          int stopId,
                                          int routeId,
                                          string time1,
                                          string time2)
        {
            var time = TimeSpan.Parse(currentTime);
            var arrivalTimes = _sut.GetArrivalTimes(time, stopId, routeId);

            Assert.That(arrivalTimes.Length, Is.EqualTo(2));
            Assert.That(arrivalTimes[0], Is.EqualTo(TimeSpan.Parse(time1)));
            Assert.That(arrivalTimes[1], Is.EqualTo(TimeSpan.Parse(time2)));
        }

        [TestCase("00:03:00", 9, 2, "00:22:00", "00:37:00")]
        public void ShouldGetArrivalTimesSpotCheck(string currentTime,
                                                   int stopId,
                                                   int routeId,
                                                   string time1,
                                                   string time2)
        {
            var time = TimeSpan.Parse(currentTime);
            var arrivalTimes = _sut.GetArrivalTimes(time, stopId, routeId);

            Assert.That(arrivalTimes.Length, Is.EqualTo(2));
            Assert.That(arrivalTimes[0], Is.EqualTo(TimeSpan.Parse(time1)));
            Assert.That(arrivalTimes[1], Is.EqualTo(TimeSpan.Parse(time2)));
        }

        [Test]
        public void ShouldThrowExceptionIfRouteIdIsInvalid()
        {
            const int invalidRouteId = 10;
            Assert.Throws<ArgumentException>(() => _sut.GetArrivalTimes(TimeSpan.Zero, 0, invalidRouteId));
        }

        [Test]
        public void ShouldThrowExceptionIfStopIdIsInvalid()
        {
            const int invalidStopId = 10;
            Assert.Throws<ArgumentException>(() => _sut.GetArrivalTimes(TimeSpan.Zero, invalidStopId, 0));
        }
    }
}