using LogisticService.Models;
using LogisticService.Requests;
using LogisticService.Responses;

namespace LogisticService.Services
{
	public interface IAuthenticationService
	{
		Task<User> Login(string username, string password);
		Task<AuthorizationResponse> Authorize(AuthorizationRequest authorizationRequest);
	}
}
