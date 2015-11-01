using System;

namespace CongestionCharge.Vehicles
{
	public class Car : IVehicle
	{
		public DateTime FinishTime { get; set; }
		public DateTime StartTime { get; set; }

		public decimal CalculateCharge()
		{
			var morningHoursInZone = new TimeSpan();
			var afternoonHoursInZone = new TimeSpan();

			if (IsWeekDay())
			{
				morningHoursInZone = AmountOfMorningHours(StartTime, FinishTime, morningHoursInZone);
				afternoonHoursInZone = AmountOfAfternoonHours(StartTime, FinishTime, afternoonHoursInZone);
			}

			return Convert.ToDecimal((2 * morningHoursInZone.Hours) + (2.5 * afternoonHoursInZone.Hours));
		}

		private bool IsWeekDay()
		{
			if (StartTime.DayOfWeek == DayOfWeek.Saturday ||
				StartTime.DayOfWeek == DayOfWeek.Sunday)
			{ return false; }
			return true;
		}

		private TimeSpan AmountOfMorningHours(DateTime startTime, DateTime finishTime, TimeSpan amount)
		{
			if (TimeIsBetween7and12(startTime))
			{
				//This is just allll wrong.
				//This will only work if the time period goes into the afternoon
				//what about 9 - 10
				var midDay = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day, 12, 0, 0);
				amount = midDay - StartTime;
			}

			if (DatesAreDifferentDays(startTime, finishTime))
			{
				var startOfNextDay = new DateTime(startTime.Year, startTime.Month, startTime.Day + 1);
				return AmountOfMorningHours(startOfNextDay, finishTime, amount);
			}
			return amount;
		}

		private bool TimeIsBetween7and12(DateTime dateTime)
		{
			if (dateTime.Hour >= 7 && dateTime.Hour <= 12) return true;
			return false;
		}

		private bool DatesAreDifferentDays(DateTime startTime, DateTime finishTime)
		{
			if (startTime.Day != startTime.Day) return true;
			else return false;

		}

		private TimeSpan AmountOfAfternoonHours(DateTime startTime, DateTime finishTime, TimeSpan amount)
		{
			if (TimeIsBetween12and7(startTime))
			{
				//This is just allll wrong.
				//If this isnt starting in the afternoon this will fail
				var endOfCharge = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day, 19, 0, 0);
				amount = endOfCharge - StartTime;
			}

			if (DatesAreDifferentDays(startTime, finishTime))
			{
				var startOfNextDay = new DateTime(startTime.Year, startTime.Month, startTime.Day + 1, 12, 0, 0);
				return AmountOfAfternoonHours(startOfNextDay, finishTime, amount);
			}
			return amount;
		}

		private bool TimeIsBetween12and7(DateTime dateTime)
		{
			if (dateTime.Hour >= 12 && dateTime.Hour <= 19) return true;
			return false;
		}
	}
}
