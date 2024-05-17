using LogisticService.Data;
using LogisticService.Models;
using LogisticService.Requests;
using LogisticService.Responses;
using System.IdentityModel.Tokens.Jwt;

namespace LogisticService.Services
{
	public class UserService : IAuthenticationService, IUserService
	{
		private readonly DataContext _dataContext;
		JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();


		public UserService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		private string GetUserId(string token)
		{
			var jwtToken = _tokenHandler.ReadJwtToken(token);
			var userId = jwtToken.Claims.Single(x => x.Type == "unique_name").Value;

			return userId;
		}

		public async Task<AuthorizationResponse> Authorize(AuthorizationRequest authorizationRequest)
		{
			var userId = GetUserId(authorizationRequest.Token);
			var user = _dataContext.Users.FirstOrDefault(x => x.Username == userId);

			if (user == null)
			{
				return new AuthorizationResponse()
				{
					ResponseCode = StatusCode.ClientNotFound,
					ErrorMessage = "User not found."
				};
			}

			return new AuthorizationResponse()
			{
				ClientId = userId,
				Username = user.Username,
				FirstName = user.FirstName,
				LastName = user.LastName,
			};
		}

		public async Task<User> GetUser(string username)
		{
			var user = _dataContext.Users.FirstOrDefault(x => x.Username == username);

			if (user == null)
			{
				throw new Exception("User not found.");
			}

			return user;
		}

		public async Task<User> Login(string username, string password)
		{
			var user = await GetUser(username);

			if (user == null)
			{
				throw new Exception("User not found");
			}

			if (user.Password != password)
			{
				throw new Exception("Wrong password");
			}

			return user;
		}
	}
}