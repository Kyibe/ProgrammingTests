using CongestionCharge.Charges;
using CongestionCharge.Interfaces;
using System;
using System.Collections.Generic;

namespace CongestionCharge.Vehicles
{
	public class Car : IVehicle
	{
		public DateTime EntryTime { get; set; }
		public DateTime ExitTime { get; set; }

		public decimal CalculateCharge()
		{
			var morningCharge = new Charge
			{
				StartTime = new DateTime(1, 1, 1, 7, 0, 0),
				FinishTime = new DateTime(1, 1, 1, 12, 0, 0),
				Rate = 2.0,
				DaysChargeApplies = new List<DayOfWeek>
				{
					DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday
				}
			};

			var afternoonCharge = new Charge
			{
				StartTime = new DateTime(1, 1, 1, 12, 0, 0),
				FinishTime = new DateTime(1, 1, 1, 19, 0, 0),
				Rate = 2.5,
				DaysChargeApplies = new List<DayOfWeek>
				{
					DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday
				}
			};

			var charge = morningCharge.CalculateCharge(EntryTime, ExitTime) + afternoonCharge.CalculateCharge(EntryTime, ExitTime);
			return Convert.ToDecimal(charge);
		}
	}
}
