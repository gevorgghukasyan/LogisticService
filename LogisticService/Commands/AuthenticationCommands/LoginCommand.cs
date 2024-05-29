using LogisticService.Models.Authentication;
using MediatR;

namespace LogisticService.Commands.AuthenticationCommands
{
    public class LoginCommand : IRequest<User>
	{
		public LoginCommand(string username, string password)
		{
			Username = username;
			Password = password;
		}

		public string Username { get; set; }
		public string Password { get; set; }

		//public LoginModel LoginModel { get; set; }

		//public LoginCommand(LoginModel loginModel)
		//{
		//	LoginModel = loginModel;
		//}
	}
}
