using Microsoft.IdentityModel.JsonWebTokens;
using MovieTicket.Application.DataTransferObjs.Auth;
using System.Security.Claims;

namespace WebUI.Authentication
{
    public static class DecryptJWTService
    {
        public static CustomUserClaims DecryptToken(string jwtToken)
        {
            if (string.IsNullOrEmpty(jwtToken))
                return new CustomUserClaims();
            var handler = new JsonWebTokenHandler();
            var token = handler.ReadJsonWebToken(jwtToken);
            var username = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name);
            var role = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role);
            var email = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            var userid = token.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            return new CustomUserClaims(username!.Value, email!.Value, role!.Value, userid!.Value.ToString());
        }
    }
}