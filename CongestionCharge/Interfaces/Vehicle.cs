using CongestionCharge.Charges;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CongestionCharge.Interfaces
{
	public abstract class Vehicle
	{
		public DateTime ExitTime { get; set; }
		public DateTime EntryTime { get; set; }
		public List<Charge> Charges { get; set; }

		public decimal CalculateCharge()
		{
			return Charges.Sum(x => x.CalculateCharge(EntryTime, ExitTime));
		}
	}
}