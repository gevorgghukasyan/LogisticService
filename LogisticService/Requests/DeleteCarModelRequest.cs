namespace LogisticService.Requests
{
	public class DeleteCarModelRequest
	{
		public DeleteCarModelRequest(string brand, string token, string modelName)
		{
			Brand = brand;
			Token = token;
			ModelName = modelName;
		}

		public string Brand { get; set; }
		public string Token { get; set; }
		public string ModelName { get; set; }
	}
}
