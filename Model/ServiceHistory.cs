using System;

namespace Model;

public class ServiceHistory
{
	public int ServiceReferenceId { get; set; }
	public DateTime ServiceDate { get; set; }
	public string ServiceDescription { get; set; }
	public string ServiceWorkerName { get; set; }

	public ServiceHistory()
	{

	}
}

