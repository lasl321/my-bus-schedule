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

        [TestCase("", 1, 1)]
        public void ShouldGetArrivalTimes(string currentTime, int stopId, int routeId)
        {
            var time = DateTime.Parse(currentTime);
            var arrivalTimes = _sut.GetArrivalTimes(time, stopId, routeId);
            Assert.That(arrivalTimes.Length, Is.EqualTo(2));
        }
    }
}