namespace LogisticService.Requests
{
	public class ContainerRequest
	{
		public ContainerRequest(bool inClose, string token)
		{
			InClose = inClose;
			Token = token;
		}

		public bool InClose { get; set; }
		public string Token { get; set; }
	}
}
