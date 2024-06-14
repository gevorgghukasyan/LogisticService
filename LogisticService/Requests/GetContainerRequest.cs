namespace LogisticService.Requests
{
	public class GetContainerRequest
	{
		public string Token { get; set; }

		public GetContainerRequest(string token)
		{
			Token = token;
		}
	}
}
