using Microsoft.AspNetCore.Identity.Data;
using MovieTicket.Application.DataTransferObjs.Auth;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient httpClient;

        public LoginService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ResponseObject<LoginDto>> Login(LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            var response = await httpClient.PostAsJsonAsync("api/Auth/Login", loginRequest, cancellationToken);
            return await response.Content.ReadFromJsonAsync<ResponseObject<LoginDto>>(cancellationToken: cancellationToken);
        }
    }
}