using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MovieTicket.Application.DataTransferObjs.Auth;
using System.Security.Claims;

namespace MovieTicket.BlazorServer.Authentication
{
    public class CustomAuthenticationStateProvider(ILocalStorageService localStorageService) : AuthenticationStateProvider
    {
        private ClaimsPrincipal anon = new ClaimsPrincipal(new ClaimsIdentity());

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(Constants.JWTToken))
                    return await Task.FromResult(new AuthenticationState(anon));

                var getUserClaims = DecryptJWTService.DecryptToken(Constants.JWTToken);
                if (getUserClaims == null)
                    return await Task.FromResult(new AuthenticationState(anon));

                var claimsPrincipal = SetClaimPrincipal(getUserClaims);
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch (Exception)
            {
                return await Task.FromResult(new AuthenticationState(anon));
            }
        }

        public static ClaimsPrincipal SetClaimPrincipal(CustomeUserClaims claims)
        {
            if (claims.Username is null) return new ClaimsPrincipal();
            return new ClaimsPrincipal(new ClaimsIdentity(
                new List<Claim>()
            {
                                new Claim(ClaimTypes.Name, claims.Username),
                                new Claim(ClaimTypes.Email, claims.Email),
                                new Claim(ClaimTypes.Role, claims.Role)
            }, "jwt"));
        }

        public void UpdateAuthenticationState(string jwtToken)
        {
            var clamimsPrincipal = new ClaimsPrincipal();
            if (!string.IsNullOrEmpty(jwtToken))
            {
                Constants.JWTToken = jwtToken;
                var getUserClaims = DecryptJWTService.DecryptToken(jwtToken);
                clamimsPrincipal = SetClaimPrincipal(getUserClaims);
            }
            else
            {
                Constants.JWTToken = null;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(clamimsPrincipal)));
        }
    }
}