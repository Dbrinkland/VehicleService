using System;

namespace Model;

public class Vehicle
{
	public int VehicleId { get; set; }
	public string VehicleBrand { get; set; }
	public int VehicleRegNr { get; set; }
	public int MilesDriven { get; set; }

	public List<ImageHistory> ImageHistory { get; set; }

	public List<ServiceHistory> ServiceHistory { get; set; }

	public Vehicle()
	{

	}
}

