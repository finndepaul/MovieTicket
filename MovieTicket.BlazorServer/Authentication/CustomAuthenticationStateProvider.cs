using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MovieTicket.Application.DataTransferObjs.Auth;
using System.Security.Claims;

namespace MovieTicket.BlazorServer.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        private ClaimsPrincipal anon = new ClaimsPrincipal(new ClaimsIdentity());

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                //if (string.IsNullOrEmpty(Constants.JWTToken))
                //    return await Task.FromResult(new AuthenticationState(anon));

                //var getUserClaims = DecryptJWTService.DecryptToken(Constants.JWTToken);
                //if (getUserClaims == null)
                //    return await Task.FromResult(new AuthenticationState(anon));

                var jwtToken = await _localStorageService.GetItemAsync<string>("JWTToken");
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
            //if (!string.IsNullOrEmpty(jwtToken))
            //{
            //    Constants.JWTToken = jwtToken;
            //    var getUserClaims = DecryptJWTService.DecryptToken(jwtToken);
            //    claimsPrincipal = SetClaimPrincipal(getUserClaims);
            //}
            //else
            //{
            //    Constants.JWTToken = null;
            //}
            if (!string.IsNullOrEmpty(jwtToken))
            {
                await _localStorageService.SetItemAsync("JWTToken", jwtToken);
                var getUserClaims = DecryptJWTService.DecryptToken(jwtToken);
                claimsPrincipal = SetClaimPrincipal(getUserClaims);
            }
            else
            {
                await _localStorageService.RemoveItemAsync("JWTToken");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}