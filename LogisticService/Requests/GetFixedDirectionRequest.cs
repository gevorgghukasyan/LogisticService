namespace LogisticService.Requests
{
	public class GetFixedDirectionRequest
	{
		public GetFixedDirectionRequest(string from, string to, string token)
		{
			From = from;
			To = to;
			Token = token;
		}

		public string From { get; set; }
		public string To { get; set; }
		public string Token { get; set; }
	}
}
