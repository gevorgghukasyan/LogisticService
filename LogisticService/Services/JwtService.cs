using LogisticService.Models;
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

		public string GenerateToken(User user)
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

				Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
				Issuer = _issuer,
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}
