using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace MovieTicket.BlazorServer.Authentication
{
    public class CustomAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private string _failReason;

        public CustomAuthenticationHandler(
            AuthenticationStateProvider authStateProvider,
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder)
            : base(options, logger, encoder)
        {
            _authStateProvider = authStateProvider;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            bool isAuthenticated = authState.User.Identity?.IsAuthenticated == true;
            Console.WriteLine(isAuthenticated);

            if (authState.User.Identity?.IsAuthenticated == true)
            {
                Logger.LogInformation("User is authenticated.");
                return AuthenticateResult.Success(new AuthenticationTicket(authState.User, Scheme.Name));
            }
            else
            {
                _failReason = "User is not authenticated.";
                Logger.LogWarning(_failReason);
                return AuthenticateResult.Fail(_failReason);
            }
        }

        protected override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.StatusCode = 401;

            if (_failReason != null)
            {
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = _failReason;
            }

            return Task.CompletedTask;
        }
    }
}