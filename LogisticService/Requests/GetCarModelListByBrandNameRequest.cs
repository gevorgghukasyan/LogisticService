namespace LogisticService.Requests
{
	public class GetCarModelListByBrandNameRequest
	{
		public GetCarModelListByBrandNameRequest(string brandName, string token)
		{
			BrandName = brandName;
			Token = token;
		}

		public string BrandName { get; set; }
		public string Token { get; set; }
	}
}
