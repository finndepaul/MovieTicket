using MovieTicket.Application.DataTransferObjs.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MovieTicket.Infrastructure.Extensions
{
    public static class DecryptJWTService
    {
        public static CustomeUserClaims DecryptToken(string jwtToken)
        {
            try
            {
                if (string.IsNullOrEmpty(jwtToken))
                    return new CustomeUserClaims();
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(jwtToken);
                var username = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
                var role = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
                var email = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
                return new CustomeUserClaims(username!.Value, email!.Value, role!.Value);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}