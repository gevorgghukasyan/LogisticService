using LogisticService.Data;
using LogisticService.Models.Authentication;
using LogisticService.Requests;
using LogisticService.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

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

			//if (user == null)
			//{
			//	throw new Exception("User not found");
			//}
			//if (user.Password != PasswordHasher.HashPassword(password))
			//{
			//	throw new Exception("Wrong username or password");
			//}

			if (!PasswordHasher.VerifyPassword(password, user.Password) || user == null || user.Username.ToLowerInvariant() != username.ToLowerInvariant())
			{
				throw new Exception("Wrong username or password");
			}

			return user;
		}
	}

	public static class PasswordHasher
	{
		public static string HashPassword(string password, int iterations = 10000)
		{
			// Generate a random salt
			byte[] salt;
			new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

			// Create the Rfc2898DeriveBytes and get the hash value
			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
			byte[] hash = pbkdf2.GetBytes(20);

			// Combine the salt and password bytes for later use
			byte[] hashBytes = new byte[36];
			Array.Copy(salt, 0, hashBytes, 0, 16);
			Array.Copy(hash, 0, hashBytes, 16, 20);

			// Turn the combined salt+hash into a string for storage
			string hashedPassword = Convert.ToBase64String(hashBytes);

			return hashedPassword;
		}

		public static bool VerifyPassword(string password, string hashedPassword, int iterations = 10000)
		{
			// Extract the bytes
			byte[] hashBytes = Convert.FromBase64String(hashedPassword);

			// Get the salt
			byte[] salt = new byte[16];
			Array.Copy(hashBytes, 0, salt, 0, 16);

			// Compute the hash on the password the user entered
			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
			byte[] hash = pbkdf2.GetBytes(20);

			// Compare the results
			for (int i = 0; i < 20; i++)
				if (hashBytes[i + 16] != hash[i])
					return false;

			return true;
		}
	}
}