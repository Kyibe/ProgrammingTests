using System;

namespace CongestionCharge.Vehicles
{
    public class Car : IVehicle
    {
        public DateTime FinishTime { get; set; }
        public DateTime StartTime { get; set; }

        public decimal CalculateCharge()
        {
            throw new NotImplementedException();
        }
    }
}
