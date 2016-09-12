using System;
using API.Controllers;
using API.Scheduling;
using Moq;
using NUnit.Framework;

namespace API.Test.Unit
{
    internal class ArrivalsControllerTests
    {
        private Mock<ISchedulingEngine> _schedulingEngine;
        private ArrivalsController _sut;
        private Mock<ITimeProvider> _timeProvider;

        [SetUp]
        public void SetUp()
        {
            _schedulingEngine = new Mock<ISchedulingEngine>();
            _timeProvider = new Mock<ITimeProvider>();
            _sut = new ArrivalsController(_schedulingEngine.Object, _timeProvider.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _schedulingEngine.VerifyAll();
            _timeProvider.VerifyAll();
        }

        [Test]
        public void ShouldGetArrivals()
        {
            const int stopId = 1;
            var x1203Am = TimeSpan.Zero.Add(TimeSpan.FromMinutes(3));

            _timeProvider.Setup(x => x.CurrentTime).Returns(x1203Am);

            _schedulingEngine.Setup(x => x.GetArrivalTimes(x1203Am, stopId, 0));
            _schedulingEngine.Setup(x => x.GetArrivalTimes(x1203Am, stopId, 1));
            _schedulingEngine.Setup(x => x.GetArrivalTimes(x1203Am, stopId, 2));

            _sut.GetArrivals(stopId);
        }
    }
}