using System;
using System.Collections.Generic;
using System.Linq;

using CongestionCharge.Core.Charges;

namespace CongestionCharge.Core.Interfaces
{


    public abstract class Vehicle
    {
        public DateTime ExitTime { get; set; }
        public DateTime EntryTime { get; set; }
        public abstract List<Charge> Charges { get; }

        public decimal CalculateCharge()
        {
            return this.Charges.Sum(x => x.CalculatingCongustionCharge(this.EntryTime, this.ExitTime));
        }
    }
}