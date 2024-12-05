using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Enums;
using System.Net.Http.Json;
using WebUI.Services.Interfaces;

namespace WebUI.Services.Implements
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

        public async Task<ResponseObject<bool>> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync("api/AccountUtilities/ForgotPassword", request);
            var readObj = await result.Content.ReadFromJsonAsync<ResponseObject<bool>>();
            return new ResponseObject<bool>()
            {
                Data = readObj.Data,
                Message = readObj.Message,
                Status = readObj.Status
            };
        }

        public async Task<ResponseObject<Guid>> SendEmail(string email, EmailType type)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/AccountUtilities/SendEmail?email={email}&type={type}", new { email, type });
            var readObj = await response.Content.ReadFromJsonAsync<ResponseObject<Guid>>();
            return new ResponseObject<Guid>()
            {
                Data = readObj.Data,
                Message = readObj.Message,
                Status = readObj.Status
            };
        }
    }
}
