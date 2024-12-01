using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MovieTicket.Application.DataTransferObjs.Auth;
using System.Security.Claims;

namespace MovieTicket.BlazorServer.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly ProtectedSessionStorage _protectedSessionStorage;

        public CustomAuthenticationStateProvider()
        {
            //_protectedSessionStorage = protectedSessionStorage;

        }
        private ClaimsPrincipal anon = new ClaimsPrincipal(new ClaimsIdentity());


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                //string jwtToken = await _localStorageService.GetItemAsStringAsync("JWTToken");
                string jwtToken = Constants.Token;
                //var result = await _protectedSessionStorage.GetAsync<string>("JWTToken");
                //var jwtToken = result.Success ? result.Value : null;
                //var jwtToken = _httpContextAccessor.HttpContext?.Request.Cookies["JWTToken"];
                if (string.IsNullOrEmpty(jwtToken))
                    return await Task.FromResult(new AuthenticationState(anon));

                var getUserClaims = DecryptJWTService.DecryptToken(jwtToken);
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

        public static ClaimsPrincipal SetClaimPrincipal(CustomUserClaims claims)
        {
            if (claims.Username is null) return new ClaimsPrincipal();
            return new ClaimsPrincipal(new ClaimsIdentity(
                new List<Claim>()
            {
                    new Claim(ClaimTypes.Name, claims.Username),
                    new Claim(ClaimTypes.Email, claims.Email),
                    new Claim(ClaimTypes.Role, claims.Role),
                    new Claim(ClaimTypes.NameIdentifier, claims.UserId)
            }, "jwt"));

        }

        public async Task UpdateAuthenticationState(string jwtToken)
        {
            var claimsPrincipal = new ClaimsPrincipal();
            if (!string.IsNullOrEmpty(jwtToken))
            {

                var getUserClaims = DecryptJWTService.DecryptToken(jwtToken);
                claimsPrincipal = SetClaimPrincipal(getUserClaims);

            }
            else
            {
                Constants.Token = "";
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}