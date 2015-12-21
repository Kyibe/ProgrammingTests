using CongestionCharge.Charges;
using CongestionCharge.Interfaces;
using System;
using System.Collections.Generic;

namespace CongestionCharge.Vehicles
{
	public class Van : Vehicle
	{
		public Van()
		{
			var morningCharge = new Charge
			{
				StartTime = new TimeSpan(7, 0, 0),
				FinishTime = new TimeSpan(12, 0, 0),
				Rate = 2.0M,
				DaysChargeApplies = new List<DayOfWeek>
				{
					DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday
				}
			};

			var afternoonCharge = new Charge
			{
				StartTime = new TimeSpan(12, 0, 0),
				FinishTime = new TimeSpan(19, 0, 0),
				Rate = 2.5M,
				DaysChargeApplies = new List<DayOfWeek>
				{
					DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday
				}
			};

			Charges = new List<Charge>
			{
				morningCharge, afternoonCharge
			};
		}
	}
}
