using System;
using CongestionCharge.Core.Vehicles;
using NUnit.Framework;

namespace UnitTests.Core.CongestionCharges
{
    [TestFixture]
    public class VanUnitTests
    {
        private Van _instance;

        [SetUp]
        public void SetUp()
        {
            this._instance = new Van();
        }

        [Test]
        public void VanCharge_WHERE_out_of_hours()
        {
            // arrange
            this._instance.EntryTime = new DateTime(2008, 4, 24, 19, 0, 0);
            this._instance.ExitTime = new DateTime(2008, 4, 25, 7, 0, 0);

            // act
            var actual = this._instance.CalculateCharge();

            // assert
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void VanCharge_WHERE_weekend_charge()
        {
            // arrange
            this._instance.EntryTime = new DateTime(2008, 4, 26, 7, 0, 0);
            this._instance.ExitTime = new DateTime(2008, 4, 26, 19, 0, 0);

            // act
            var actual = this._instance.CalculateCharge();

            // assert
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void VanCharge_WHERE_Am_Charge()
        {
            // arrange
            this._instance.EntryTime = new DateTime(2008, 4, 24, 11, 0, 0);
            this._instance.ExitTime = new DateTime(2008, 4, 24, 12, 0, 0);

            // act
            var actual = this._instance.CalculateCharge();

            // assert
            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void VanCharge_WHERE_Pm_Charge()
        {
            // arrange
            this._instance.EntryTime = new DateTime(2008, 4, 24, 12, 0, 0);
            this._instance.ExitTime = new DateTime(2008, 4, 24, 13, 0, 0);

            // act
            var actual = this._instance.CalculateCharge();

            // assert
            Assert.That(actual, Is.EqualTo(2.5));
        }


        [Test]
        public void VanCharge_WHERE_AM_and_PM_charges()
        {
            // arrange
            this._instance.EntryTime = new DateTime(2008, 4, 24, 11, 32, 0);
            this._instance.ExitTime = new DateTime(2008, 4, 24, 14, 42, 0);

            // act
            var actual = this._instance.CalculateCharge();

            // assert
            Assert.That(actual, Is.EqualTo(7.6));
        }

        [Test]
        public void VanCharge_WHERE_multiple_days()
        {
            // arrange
            this._instance.EntryTime = new DateTime(2008, 4, 24, 14, 0, 0);
            this._instance.ExitTime = new DateTime(2008, 4, 25, 11, 0, 0);

            // act
            var actual = this._instance.CalculateCharge();

            // assert
            Assert.That(actual, Is.EqualTo(20.5));
        }


        [Test]
        public void VanCharge_WHERE_multiple_day_with_weekend_AM_and_PM_charges()
        {
            // arrange
            this._instance.EntryTime = new DateTime(2008, 4, 25, 10, 23, 0);
            this._instance.ExitTime = new DateTime(2008, 4, 28, 9, 42, 0);

            // act
            var actual = this._instance.CalculateCharge();

            // assert
            Assert.That(actual, Is.EqualTo(26.1));
        }
    }
}
