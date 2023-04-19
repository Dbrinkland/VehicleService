using System;

namespace Model;

public class ServiceHistory
{
	public int ServiceReferenceId { get; set; }
	public DateTime ServiceDate { get; set; }
	public string ServiceDescription { get; set; }
	public string ServiceWorkerName { get; set; }
	public virtual Vehicle Vehicle { get; set; }


    public List<ImageHistory>? ImageHistory { get; set; }
	public List<Vehicle>? Vehicles { get; set; }

    public ServiceHistory()
    {

    }

    public ServiceHistory(int serviceReferenceId, DateTime serviceDate, string ServiceDescription, string ServiceWorkerName)
	{
		this.ServiceReferenceId = serviceReferenceId;
		this.ServiceDate = serviceDate;
		this.ServiceDescription = ServiceDescription;
		this.ServiceWorkerName = ServiceWorkerName;
}
};

