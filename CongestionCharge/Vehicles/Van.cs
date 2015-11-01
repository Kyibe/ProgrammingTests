using CongestionCharge.Interfaces;
using System;

namespace CongestionCharge.Vehicles
{
    public class Van : IVehicle
    {
        public DateTime ExitTime { get; set; }
        public DateTime EntryTime { get; set; }

        public decimal CalculateCharge()
        {
            throw new NotImplementedException();
        }
    }
}
