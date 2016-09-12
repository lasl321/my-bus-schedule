using NUnit.Framework;

namespace API.Scheduling.Test.Unit
{
    public class Tests
    {
        private SchedulingEngine _sut;

        public void SetUp()
        {
            _sut = new SchedulingEngine();
        }

        [Test]
        public void Should_2016_09_11_10_02_29()
        {
            Assert.That(true, Is.True);
        }
    }
}