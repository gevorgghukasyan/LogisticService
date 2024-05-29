namespace LogisticService.Requests
{
	public class GetCarModelRequest
	{
		public GetCarModelRequest(string brand, string modelName, string token)
		{
			Brand = brand;
			ModelName = modelName;
			Token = token;
		}

		public string Brand { get; set; }
		public string ModelName { get; set; }
		public string Token { get; set; }
	}
}
