namespace CongestionCharge.Core.Charges
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    [DebuggerDisplay("StartTime: {StartTime}, FinishTime {FinishTime}")]
    public class Charge
    {
        public TimeSpan StartTime { get; }
        public TimeSpan FinishTime { get; }
        public decimal Rate { get; set; }
        public List<DayOfWeek> DaysChargeApplies { get; set; }

        public Charge(TimeSpan startTime, TimeSpan finishTime, decimal chargePerHour, List<DayOfWeek> daysChargeApplies)
        {
            this.StartTime = startTime;
            this.FinishTime = finishTime;
            this.Rate = chargePerHour;
            this.DaysChargeApplies = daysChargeApplies;

            if (!this.IsValid()) { throw new ArgumentException("Dates are not valid. Please enter valid Dates."); }
        }

        public bool IsValid()
        {
            if (this.StartTime.TotalDays >= 1) return false;
            if (this.FinishTime.TotalDays >= 1) return false;
            if (this.FinishTime < this.StartTime) return false;
            if (this.Rate < 0) return false;

            return true;
        }

        public decimal CalculatingCongustionCharge(DateTime entryTime, DateTime leaveTime)
        {
            var timeInZone = this.GetTimeWithinZone(entryTime, leaveTime, new TimeSpan());
            return this.CalulateValueOfCharge(timeInZone);
        }

        private decimal CalulateValueOfCharge(TimeSpan timeInZone)
        {
            var totalHours = (decimal)timeInZone.TotalMinutes / 60M;
            var exactCharge = totalHours * this.Rate;
            return Math.Floor(exactCharge * 10) / 10;
        }

        private TimeSpan GetTimeWithinZone(DateTime entryTime, DateTime leaveTime, TimeSpan timeInZone)
        {
            if (this.IsChargableTime(entryTime, leaveTime))
            {
                timeInZone += this.GetAmountOfTimeInZone(entryTime, leaveTime);
            }

            if (this.HasAnotherDayInChargeZone(entryTime, leaveTime))
            {
                var startOfNextDay = entryTime.Date.AddDays(1);
                return this.GetTimeWithinZone(startOfNextDay, leaveTime, timeInZone);
            }

            return timeInZone;
        }

        private bool IsChargableTime(DateTime entryTime, DateTime leaveTime)
        {
            return this.DaysChargeApplies.Contains(entryTime.DayOfWeek);
        }

        private bool HasAnotherDayInChargeZone(DateTime entryTime, DateTime leaveTime)
        {
            return entryTime.Day != leaveTime.Day;
        }

        private TimeSpan GetAmountOfTimeInZone(DateTime entryTime, DateTime leaveTime)
        {
            var timeToStartCharge = entryTime.TimeOfDay > this.StartTime
                                        ? entryTime.TimeOfDay
                                        : this.StartTime;

            var timeToEndCharge = this.FindTimeToEndCharge(entryTime, leaveTime);


            var amountOfTimeInZone = timeToEndCharge - timeToStartCharge;
            return amountOfTimeInZone < new TimeSpan()
                            ? new TimeSpan()
                            : amountOfTimeInZone;
        }

        private TimeSpan FindTimeToEndCharge(DateTime entryTime, DateTime leaveTime)
        {
            if (!entryTime.Date.Equals(leaveTime.Date)) { return this.FinishTime; }

            return leaveTime.TimeOfDay > this.FinishTime
                                    ? this.FinishTime
                                    : leaveTime.TimeOfDay;
        }
    }
}
