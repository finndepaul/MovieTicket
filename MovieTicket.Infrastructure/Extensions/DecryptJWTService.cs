using MovieTicket.Application.DataTransferObjs.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MovieTicket.Infrastructure.Extensions
{
	public static class DecryptJWTService
	{
		public static CustomUserClaims DecryptToken(string jwtToken)
		{
			try
			{
				if (string.IsNullOrEmpty(jwtToken))
					return new CustomUserClaims();
				var handler = new JwtSecurityTokenHandler();
				var token = handler.ReadJwtToken(jwtToken);
				var username = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
				var role = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
				var email = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
				return new CustomUserClaims(username!.Value, email!.Value, role!.Value);
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}