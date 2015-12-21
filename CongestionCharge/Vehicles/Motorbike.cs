using CongestionCharge.Charges;
using CongestionCharge.Interfaces;
using System;
using System.Collections.Generic;

namespace CongestionCharge.Vehicles
{
	public class MotorBike : Vehicle
	{
		public MotorBike()
		{
			Charges = new List<Charge>
			{
				new Charge
				{
					StartTime = new TimeSpan(7, 0, 0),
					FinishTime = new TimeSpan(19, 0, 0),
					Rate = 1M,
					DaysChargeApplies = new List<DayOfWeek>
					{
						DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday
					}
				}
			};
		}
	}
}
