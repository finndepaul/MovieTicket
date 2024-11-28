using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.BlazorServer.Services.Interfaces;
using MovieTicket.Domain.Enums;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class AccountUtilitiesService : IAccountUtilitiesService
    {
        private readonly HttpClient _httpClient;

        public AccountUtilitiesService(HttpClient httpClient)
        {
            _httpClient = httpClient; 
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var response = await _httpClient.PutAsJsonAsync("api/AccountUtilities/ChangePassword", request, cancellationToken);
            return response.IsSuccessStatusCode;
        }
        
    }
}
