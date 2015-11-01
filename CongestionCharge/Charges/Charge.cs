using System;
using System.Collections.Generic;

namespace CongestionCharge.Charges
{
	public class Charge
	{
		//Might have to some validation on properties.
		//What happens if start time is before finish time
		//What about negative rate
		//What about if no days a specified
		public DateTime StartTime { get; set; }
		public DateTime FinishTime { get; set; }
		public double Rate { get; set; }
		public List<DayOfWeek> DaysChargeApplies { get; set; }

		//assuming over one day only.
		public double CalculateCharge(DateTime entryTime, DateTime leaveTime)
		{
			if (IsTimeWithinCharge(entryTime))
			{
				var timeBetweenEntryAndLeave = GetTimeDifference(entryTime, leaveTime);
				//Dont like this, this is working on a side affect. How does anyone know that if you pass null this happens
				var timeBetweenEntryAndChargeFinish = GetTimeDifference(entryTime, null);

				var hoursInChargeZone = timeBetweenEntryAndLeave < timeBetweenEntryAndChargeFinish ? timeBetweenEntryAndLeave.TotalHours : timeBetweenEntryAndChargeFinish.TotalHours;

				return hoursInChargeZone * Rate;
			}

			return 0;
		}

		private bool IsTimeWithinCharge(DateTime entryTime)
		{
			return DaysChargeApplies.Contains(entryTime.DayOfWeek)
				&& entryTime.Hour >= StartTime.Hour
				&& entryTime.Hour < FinishTime.Hour;
		}

		private TimeSpan GetTimeDifference(DateTime entryTime, DateTime? leaveTime)
		{
			// don't like this
			if (leaveTime == null)
			{
				leaveTime = new DateTime(entryTime.Year, entryTime.Month, entryTime.Day,
										FinishTime.Hour, FinishTime.Minute, FinishTime.Second);
			}

			return leaveTime - entryTime ?? new TimeSpan();
		}
	}
}
