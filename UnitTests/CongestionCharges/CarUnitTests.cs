using CongestionCharge.Vehicles;
using NUnit.Framework;
using System;

namespace UnitTests.CongestionCharges
{
    [TestFixture]
    public class CarUnitTests
    {
        private Car _instance;

        [SetUp]
        public void SetUp()
        {
            _instance = new Car();
        }

        [Test]
        public void CarCharge_WHERE_out_of_hours()
        {
            //arrange
            _instance.StartTime = new DateTime(2008, 4, 24, 19, 0, 0);
            _instance.FinishTime = new DateTime(2008, 4, 25, 7, 0, 0);

            //act
            var actual = _instance.CalculateCharge();

            //assert
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void CarCharge_WHERE_weekend_charge()
        {
            //arrange
            _instance.StartTime = new DateTime(2008, 4, 26, 7, 0, 0);
            _instance.FinishTime = new DateTime(2008, 4, 26, 19, 0, 0);

            //act
            var actual = _instance.CalculateCharge();

            //assert
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void CarCharge_WHERE_Am_Charge()
        {
            //arrange
            _instance.StartTime = new DateTime(2008, 4, 24, 11, 0, 0);
            _instance.FinishTime = new DateTime(2008, 4, 24, 12, 0, 0);

            //act
            var actual = _instance.CalculateCharge();

            //assert
            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void CarCharge_WHERE_Pm_Charge()
        {
            //arrange
            _instance.StartTime = new DateTime(2008, 4, 24, 12, 0, 0);
            _instance.FinishTime = new DateTime(2008, 4, 24, 13, 0, 0);

            //act
            var actual = _instance.CalculateCharge();

            //assert
            Assert.That(actual, Is.EqualTo(2.5));
        }


        [Test]
        public void CarCharge_WHERE_AM_and_PM_charges()
        {
            //arrange
            _instance.StartTime = new DateTime(2008, 4, 24, 11, 32, 0);
            _instance.FinishTime = new DateTime(2008, 4, 24, 14, 42, 0);

            //act
            var actual = _instance.CalculateCharge();

            //assert
            Assert.That(actual, Is.EqualTo(7.6));
        }

        [Test]
        public void CarCharge_WHERE_multiple_days()
        {
            //arrange
            _instance.StartTime = new DateTime(2008, 4, 25, 14, 0, 0);
            _instance.FinishTime = new DateTime(2008, 4, 26, 11, 0, 0);

            //act
            var actual = _instance.CalculateCharge();

            //assert
            Assert.That(actual, Is.EqualTo(20.5));
        }


        [Test]
        public void CarCharge_WHERE_multiple_day_with_weekend_AM_and_PM_charges()
        {
            //arrange
            _instance.StartTime = new DateTime(2008, 4, 25, 10, 23, 0);
            _instance.FinishTime = new DateTime(2008, 4, 28, 9, 42, 0);

            //act
            var actual = _instance.CalculateCharge();

            //assert
            Assert.That(actual, Is.EqualTo(24.8));
        }
    }
}
