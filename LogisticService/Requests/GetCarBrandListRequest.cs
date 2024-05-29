namespace LogisticService.Requests
{
	public class GetCarBrandListRequest
	{
		public string Token { get; set; }

		public GetCarBrandListRequest(string token)
		{
			Token = token;
		}
	}
}
