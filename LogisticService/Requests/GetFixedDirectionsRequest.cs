namespace LogisticService.Requests
{
	public class GetFixedDirectionsRequest
	{
		public string Token { get; set; }

		public GetFixedDirectionsRequest(string token)
		{
			Token = token;
		}
	}
}
