using LogisticService.Models.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LogisticService.Services
{
	public class JwtService
	{
		private readonly string _secretKey;
		private readonly string _issuer;

		public JwtService(string secretKey, string issuer)
		{
			_secretKey = secretKey;
			_issuer = issuer;
		}

		//public string GenerateToken(User user)
		//{
		//	var tokenHandler = new JwtSecurityTokenHandler();
		//	var key = Encoding.ASCII.GetBytes(_secretKey);

		//	var tokenDescriptor = new SecurityTokenDescriptor
		//	{
		//		Subject = new ClaimsIdentity(new Claim[]
		//		{
		//			new Claim(ClaimTypes.Name, user.Username),
		//			new Claim($"UserId", user.Id.ToString()),
		//		}),

		//		Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
		//		Issuer = _issuer,
		//		SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		//	};
		//	var token = tokenHandler.CreateToken(tokenDescriptor);

		//	return tokenHandler.WriteToken(token);
		//}

		public TokenResponse GenerateTokens(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_secretKey);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
			new Claim(ClaimTypes.Name, user.Username),
			new Claim($"UserId", user.Id.ToString()),
				}),

				Expires = DateTime.UtcNow.AddHours(1), // Access token expiration time
				Issuer = _issuer,
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var refreshTokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
			new Claim(ClaimTypes.Name, user.Username),
			new Claim($"UserId", user.Id.ToString()),
			new Claim("RefreshToken", Guid.NewGuid().ToString()) // Include refresh token in claims
				}),

				Expires = DateTime.UtcNow.AddHours(24), // Refresh token expiration time
				Issuer = _issuer,
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var accessToken = tokenHandler.CreateToken(tokenDescriptor);
			var refreshToken = tokenHandler.CreateToken(refreshTokenDescriptor);

			return new TokenResponse() { AccessToken = tokenHandler.WriteToken(accessToken), RefreshToken = tokenHandler.WriteToken(refreshToken) };
		}

		public TokenResponse RefreshToken(string refreshToken)
		{
			try
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var key = Encoding.ASCII.GetBytes(_secretKey);

				var validationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = false,
					ValidateLifetime = false, // We don't need to validate lifetime for refresh tokens
					ValidateIssuerSigningKey = true,
					ValidIssuer = _issuer,
					ValidAudience = _issuer,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ClockSkew = TimeSpan.Zero // Set to zero to avoid any clock skew issues
				};

				SecurityToken validatedToken;
				var principal = tokenHandler.ValidateToken(refreshToken, validationParameters, out validatedToken);

				if (validatedToken is not JwtSecurityToken jwtToken ||
					!jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
				{
					throw new SecurityTokenException("Invalid token");
				}

				// Check if the RefreshToken claim is present
				var refreshTokenClaim = principal.Claims.FirstOrDefault(c => c.Type == "RefreshToken");
				if (refreshTokenClaim == null)
				{
					throw new SecurityTokenException("Refresh token claim not found");
				}

				// Extract user information from the validated token
				var user = GetUserFromTokenClaims(principal.Claims);

				// Generate a new access token (and optionally a new refresh token)
				return GenerateTokens(user);
			}
			catch (SecurityTokenException ex)
			{
				// Handle token validation errors
				throw new SecurityTokenException("Token refresh failed", ex);
			}
			catch (Exception ex)
			{
				// Handle other unexpected errors
				throw new Exception("An error occurred while refreshing tokens", ex);
			}
		}

		private User GetUserFromTokenClaims(IEnumerable<Claim> claims)
		{
			var userIdClaim = claims.FirstOrDefault(c => c.Type == "UserId");
			var usernameClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
		//	var balanceClaim = claims.FirstOrDefault(c => c.Type == "Balance");

			if (userIdClaim == null || usernameClaim == null /*|| balanceClaim == null*/)
			{
				throw new ArgumentException("Invalid token claims");
			}

			if (!int.TryParse(userIdClaim.Value, out int userId))
			{
				throw new ArgumentException("Invalid UserId claim value");
			}

			//if (!decimal.TryParse(balanceClaim.Value, out decimal balance))
			//{
			//	throw new ArgumentException("Invalid Balance claim value");
			//}

			var user = new User
			{
				Id = userId,
				Username = usernameClaim.Value,
				// Add other user properties as needed
			};

			return user;
		}
	}
}