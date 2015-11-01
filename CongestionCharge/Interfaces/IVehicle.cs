using System;

namespace CongestionCharge.Interfaces
{
	public interface IVehicle
	{
		DateTime ExitTime { get; set; }
		DateTime EntryTime { get; set; }

		decimal CalculateCharge();
	}
}