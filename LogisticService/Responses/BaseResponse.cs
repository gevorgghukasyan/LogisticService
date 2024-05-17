namespace LogisticService.Responses
{
	public record BaseResponse
	{
		public BaseResponse()
		{

		}

		public BaseResponse(string? errorMessage)
		{
			ErrorMessage = errorMessage;
		}

		public bool IsSuccess => ErrorMessage == null;
		public string? ErrorMessage { get; set; }
	}
}
