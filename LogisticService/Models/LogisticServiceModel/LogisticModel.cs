namespace LogisticService.Models.LogisticServiceModel
{
	public class LogisticModel
	{
		public LogisticModel(string carType, bool inClose, string from, string to)
		{
			CarType = carType;
			InClose = inClose;
			From = from;
			To = to;
		}

		public string CarType { get; set; }
		public bool InClose { get; set; }
		public string From { get; set; }
		public string To { get; set; }
	}
}
