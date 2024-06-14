namespace LogisticService.Requests
{
	public class GetCarTypeRequest
	{
		public GetCarTypeRequest(string name, string token)
		{
			Name = name;
			Token = token;
		}

		public string Name { get; set; }
		public string Token { get; set; }
	}
}
