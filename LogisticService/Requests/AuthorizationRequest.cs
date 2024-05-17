namespace LogisticService.Requests
{
	public class AuthorizationRequest
	{
		public AuthorizationRequest(string token, int productId)
		{
			Token = token;
			ProductId = productId;
		}

		public string Token { get; set; }
		public int ProductId { get; set; }
	}
}
