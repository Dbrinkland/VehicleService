using System;

namespace Model;

public class VehicleImage
{
	public Vehicle Vehicle { get; set; }
	public Uri Image { get; set; }

	// public ?? placering {get;set;} ????

	public DateTime ImageDate { get; set; }
	public string ImageDescription { get; set; }
	public string Name { get; set; }

	public VehicleImage()
	{

	}
}

