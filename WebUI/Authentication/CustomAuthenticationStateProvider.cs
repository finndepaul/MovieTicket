using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MovieTicket.Application.DataTransferObjs.Auth;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace WebUI.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly HttpClient _httpClient;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
        }
        private ClaimsPrincipal anon = new ClaimsPrincipal(new ClaimsIdentity());


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var savedToken = await _localStorageService.GetItemAsync<string>("authToken");
                if (string.IsNullOrEmpty(savedToken))
                    return new AuthenticationState(anon);

                var getUserClaims = DecryptJWTService.DecryptToken(savedToken);
                if (getUserClaims == null)
                    return await Task.FromResult(new AuthenticationState(anon));

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", savedToken);
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(savedToken), "jwt")));
            }
            catch (Exception)
            {
                return await Task.FromResult(new AuthenticationState(anon));
            }
        }

        private List<Claim>? ParseClaimsFromJwt(string savedToken)
        {
            var claims = new List<Claim>();
            var payload = savedToken.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValue = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
            keyValue.TryGetValue(ClaimTypes.Role, out object? roles);
            if (roles != null)
            {
                if (roles.ToString().Trim().Contains("["))
                {
                    var roleArray = JsonSerializer.Deserialize<string[]>(roles.ToString());
                    foreach (var role in roleArray)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }
                keyValue.Remove(ClaimTypes.Role);
            }
            claims.AddRange(keyValue.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            return claims;
        }
        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
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
                _httpClient.DefaultRequestHeaders.Authorization = null;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }


    }
}