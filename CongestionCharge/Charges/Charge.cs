using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CongestionCharge.Charges
{
	[DebuggerDisplay("StartTime: {StartTime}, FinishTime {FinishTime}")]
	public class Charge
	{
		public TimeSpan StartTime { get; set; }
		public TimeSpan FinishTime { get; set; }
		public decimal Rate { get; set; }
		public List<DayOfWeek> DaysChargeApplies { get; set; }

		public bool IsValid()
		{
			if (StartTime.TotalDays >= 1) return false;
			if (FinishTime.TotalDays >= 1) return false;
			if (FinishTime < StartTime) return false;
			if (Rate < 0) return false;

			return true;
		}

		public decimal CalculateCharge(DateTime entryTime, DateTime leaveTime)
		{
			if (!IsValid()) { throw new ArgumentException("Charge is not valid. Please enter valid fields."); }
			var timeInZone = GetTimeWithinZone(entryTime, leaveTime, new TimeSpan());
			//Horrible!
			return CalulateValueOfCharge(timeInZone);
		}

		private decimal CalulateValueOfCharge(TimeSpan timeInZone)
		{
			return Math.Floor((((decimal)timeInZone.TotalMinutes / 60M) * Rate) * 10) / 10;
		}

		private TimeSpan GetTimeWithinZone(DateTime entryTime, DateTime leaveTime, TimeSpan timeInZone)
		{
			if (IsChargableTime(entryTime, leaveTime))
			{
				timeInZone += GetAmountOfTimeInZone(entryTime, leaveTime);
			}

			if (HasAnotherDayInChargeZone(entryTime, leaveTime))
			{
				//What happens on the last day of month
				var startOfNextDay = new DateTime(entryTime.Year, entryTime.Month, entryTime.Day + 1);
				return GetTimeWithinZone(startOfNextDay, leaveTime, timeInZone);
			}

			return timeInZone;
		}

		private bool IsChargableTime(DateTime entryTime, DateTime leaveTime)
		{
			return DaysChargeApplies.Contains(entryTime.DayOfWeek);
		}

		private bool HasAnotherDayInChargeZone(DateTime entryTime, DateTime leaveTime)
		{
			return entryTime.Day != leaveTime.Day;
		}

		private TimeSpan GetAmountOfTimeInZone(DateTime entryTime, DateTime leaveTime)
		{
			var timeToStartCharge = entryTime.TimeOfDay > StartTime
										? entryTime.TimeOfDay
										: StartTime;

			var timeToEndCharge = FindTimeToEndCharge(entryTime, leaveTime);


			var amountOfTimeInZone = timeToEndCharge - timeToStartCharge;
			return amountOfTimeInZone < new TimeSpan()
							? new TimeSpan()
							: amountOfTimeInZone;
		}

		private TimeSpan FindTimeToEndCharge(DateTime entryTime, DateTime leaveTime)
		{
			if (!entryTime.Date.Equals(leaveTime.Date)) { return FinishTime; }

			return leaveTime.TimeOfDay > FinishTime
									? FinishTime
									: leaveTime.TimeOfDay;
		}
	}
}
