namespace LogisticService.Requests
{
	public class GetCarTypesRequest
	{
		public string Token { get; set; }

		public GetCarTypesRequest(string token)
		{
			Token = token;
		}
	}
}
