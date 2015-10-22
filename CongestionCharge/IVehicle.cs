using System;

namespace CongestionCharge
{
    public interface IVehicle
    {
        DateTime FinishTime { get; set; }
        DateTime StartTime { get; set; }

        decimal CalculateCharge();
    }
}