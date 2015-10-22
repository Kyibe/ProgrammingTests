using CongestionCharge.Vehicles;
using NUnit.Framework;
using System;

namespace UnitTests.CongestionCharges
{
    [TestFixture]
    public class MotorBikeUnitTests
    {
        [Test]
        public void CarCharge_WHERE_single_day_with_AM_and_PM_charges()
        {
            //arrange
            var car = new Car();
            car.StartTime = new DateTime(2008, 4, 24, 11, 32, 0);
            car.FinishTime = new DateTime(2008, 4, 24, 14, 42, 0);

            //act
            var actual = car.CalculateCharge();

            //assert
            Assert.That(actual, Is.EqualTo(7.6));
        }

        [Test]
        public void MotorBikeCharge_WHERE_single_day_with_AM_and_PM_charges()
        {
            //arrange
            var motorBike = new MotorBike();
            motorBike.StartTime = new DateTime(2008, 4, 25, 10, 23, 0);
            motorBike.FinishTime = new DateTime(2008, 4, 28, 9, 42, 0);

            //act
            var actual = motorBike.CalculateCharge();

            //assert
            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void VanCharge_WHERE_multiple_day_with_AM_and_PM_charges()
        {
            //arrange
            var van = new Van();
            van.StartTime = new DateTime(2008, 4, 25, 10, 23, 0);
            van.FinishTime = new DateTime(2008, 4, 28, 9, 42, 0);

            //act
            var actual = van.CalculateCharge();

            //assert
            Assert.That(actual, Is.EqualTo(24.8));
        }
    }
}
