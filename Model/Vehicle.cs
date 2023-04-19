using System;

namespace Model;

public class Vehicle
{
	public int VehicleId { get; set; }
	public string VehicleBrand { get; set; }
	public int VehicleRegNr { get; set; }
	public int MilesDriven { get; set; }

	public List<VehicleImage> ImageHistory { get; set; }

	public Vehicle()
	{

	}
}

