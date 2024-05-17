using Microsoft.AspNetCore.Http;

namespace LogisticService.Responses
{
	public enum StatusCode
	{
		Success = 0,
		GeneralException = 21,
		ClientNotFound = 22,
		SessionExpired = 29,
		NotAllowed = 68,
	}

	public record AuthorizationResponse : BaseResponse
	{
		public AuthorizationResponse()
		{
		}

		/// <summary>
		/// (Required)Response Code (0 in case of success)
		/// </summary>
		public StatusCode ResponseCode { get; set; }

		/// <summary>
		/// (Required)New session token for further api calls
		/// </summary>
		public string Token { get; set; }

		/// <summary>
		/// (Required)Client's unique identifier
		/// </summary>
		public string ClientId { get; set; }

		/// <summary>
		/// (Required)Client's UserName (unique per partner)
		/// </summary>
		public string Username { get; set; }

		/// <summary>
		/// (Optional)Client's FirstName
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// (Optional)Client's LastName
		/// </summary>
		public string LastName { get; set; }
	}
}
