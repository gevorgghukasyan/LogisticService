namespace LogisticService.Requests
{
	public class TariffRequest
	{
		public string FromZipCode { get; set; }
		public string ToZipCode { get; set; }
		public string ContainerType { get; set; } // "Open" or "Closed"
		public string VehicleType { get; set; } // "Sedan", "Truck", etc.
	}
}
