namespace LogisticService.Requests
{
	public class GetCarBrandByBrandRequest
	{
		public GetCarBrandByBrandRequest(string brand, string token)
		{
			Brand = brand;
			Token = token;
		}

		public string Brand { get; set; }
		public string Token { get; set; }
	}
}
