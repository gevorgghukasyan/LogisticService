using LogisticService.Requests;
using LogisticService.Responses;
using MediatR;

namespace LogisticService.Commands.AuthenticationCommands
{
	public class AuthorizeCommand : IRequest<AuthorizationResponse>
	{
		public AuthorizationRequest AuthorizationRequest { get; set; }

		public AuthorizeCommand(AuthorizationRequest authorizationRequest)
		{
			AuthorizationRequest = authorizationRequest;
		}
	}
}
