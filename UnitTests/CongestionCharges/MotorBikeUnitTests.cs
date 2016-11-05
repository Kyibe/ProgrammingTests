using System;
using CongestionCharge.Core.Vehicles;
using NUnit.Framework;

namespace UnitTests.Core.CongestionCharges
{
	[TestFixture]
	public class MotorBikeUnitTests
	{
		private MotorBike _instance;

		[SetUp]
		public void SetUp()
		{
			_instance = new MotorBike();
		}

		[Test]
		public void MotorBikeCharge_WHERE_out_of_hours()
		{
			// arrange
			_instance.EntryTime = new DateTime(2008, 4, 24, 19, 0, 0);
			_instance.ExitTime = new DateTime(2008, 4, 25, 7, 0, 0);

			// act
			var actual = _instance.CalculateCharge();

			// assert
			Assert.That(actual, Is.EqualTo(0));
		}

		[Test]
		public void MotorBikeCharge_WHERE_weekend_charge()
		{
			// arrange
			_instance.EntryTime = new DateTime(2008, 4, 26, 7, 0, 0);
			_instance.ExitTime = new DateTime(2008, 4, 27, 19, 0, 0);

			// act
			var actual = _instance.CalculateCharge();

			// assert
			Assert.That(actual, Is.EqualTo(0));
		}

		[Test]
		public void MotorBikeCharge_WHERE_Am_Charge()
		{
			// arrange
			_instance.EntryTime = new DateTime(2008, 4, 24, 11, 0, 0);
			_instance.ExitTime = new DateTime(2008, 4, 24, 12, 0, 0);

			// act
			var actual = _instance.CalculateCharge();

			// assert
			Assert.That(actual, Is.EqualTo(1));
		}

		[Test]
		public void MotorBikeCharge_WHERE_Pm_Charge()
		{
			// arrange
			_instance.EntryTime = new DateTime(2008, 4, 24, 12, 0, 0);
			_instance.ExitTime = new DateTime(2008, 4, 24, 13, 0, 0);

			// act
			var actual = _instance.CalculateCharge();

			// assert
			Assert.That(actual, Is.EqualTo(1));
		}


		[Test]
		public void MotorBikeCharge_WHERE_AM_and_PM_charges()
		{
			// arrange
			_instance.EntryTime = new DateTime(2008, 4, 24, 11, 32, 0);
			_instance.ExitTime = new DateTime(2008, 4, 24, 14, 42, 0);

			// act
			var actual = _instance.CalculateCharge();

			// assert
			Assert.That(actual, Is.EqualTo(3.1));
		}

		[Test]
		public void MotorBikeCharge_WHERE_multiple_days()
		{
			// arrange
			_instance.EntryTime = new DateTime(2008, 4, 24, 14, 0, 0);
			_instance.ExitTime = new DateTime(2008, 4, 25, 11, 0, 0);

			// act
			var actual = _instance.CalculateCharge();

			// assert
			Assert.That(actual, Is.EqualTo(9));
		}


		[Test]
		public void MotorBikeCharge_WHERE_multiple_day_with_weekend_AM_and_PM_charges()
		{
			// arrange
			_instance.EntryTime = new DateTime(2008, 4, 25, 10, 23, 0);
			_instance.ExitTime = new DateTime(2008, 4, 28, 9, 42, 0);

			// act
			var actual = _instance.CalculateCharge();

			// assert
			Assert.That(actual, Is.EqualTo(11.3));
		}
	}
}
