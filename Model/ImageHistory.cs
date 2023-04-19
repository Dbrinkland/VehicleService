﻿using System;

namespace Model;

public class ImageHistory
{
	public Vehicle Vehicle { get; set; }
	public Uri Image { get; set; }

	public string ImageURI { get; set; } // placering af image

	public DateTime ImageDate { get; set; }
	public string ImageDescription { get; set; }
	public string ImageUploaderName { get; set; }

	public ImageHistory()
	{

	}
}

