namespace LogisticService.Requests
{
	public class GetCarCrushedByTypeRequest
	{
		public GetCarCrushedByTypeRequest(bool type, string token)
		{
			Type = type;
			Token = token;
		}

		public bool Type { get; set; }
		public string Token { get; set; }
	}
}
