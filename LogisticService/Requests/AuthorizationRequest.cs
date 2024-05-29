namespace LogisticService.Requests
{
	public class AuthorizationRequest
	{
		public AuthorizationRequest(string token, int productId)
		{
			Token = token;
		}

		public string Token { get; set; }
	}
}
