using LogisticService.Commands.AuthenticationCommands;
using LogisticService.Responses;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.UserHandlers
{
	public class AuthorizeCommmandHandler : IRequestHandler<AuthorizeCommand, AuthorizationResponse>
	{
		private readonly IAuthenticationService _authenticationService;

		public AuthorizeCommmandHandler(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		public async Task<AuthorizationResponse> Handle(AuthorizeCommand request, CancellationToken cancellationToken)
		{
			return await _authenticationService.Authorize(request.AuthorizationRequest);
		}
	}
}
