using LogisticService.Commands.AuthenticationCommands;
using LogisticService.Models;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.UserHandlers
{
	public class LoginCommandHandler : IRequestHandler<LoginCommand, User>
	{
		private readonly IAuthenticationService _loginService;

		public LoginCommandHandler(IAuthenticationService loginService)
		{
			_loginService = loginService;
		}

		public async Task<User> Handle(LoginCommand request, CancellationToken cancellationToken)
		{
			var user = await _loginService.Login(request.LoginModel.Username, request.LoginModel.Password);

			return user;
		}
	}
}
