using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.UserHome;
using MovieTicket.Application.DataTransferObjs.UserHome.Requests;
using WebUI.Services.Interfaces;
using System.Net.Http.Json;

namespace WebUI.Services.Implements
{
    public class UserHomeService : IUserHomeService
    {
        private readonly HttpClient _http;

        public UserHomeService(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> AddComboToCheckAsync(ComboCheckRequest request, CancellationToken cancellationToken)
        {
            var result = await _http.PutAsJsonAsync($"api/UserHome/AddComboToCheck", request, cancellationToken);
            var message = await result.Content.ReadAsStringAsync();
            return message;
        }

        public async Task<string> AddDiscountToCheckAsync(DiscountCheckRequest request, CancellationToken cancellationToken)
        {
            var result = await _http.PutAsJsonAsync($"api/UserHome/AddDiscountToCheck", request, cancellationToken);
            var message = await result.Content.ReadAsStringAsync();
            return message;
        }

        public async Task CheckOutSuccessAsync(CheckOutSuccessRequest request, CancellationToken cancellationToken)
        {
            var result = await _http.PutAsJsonAsync("api/UserHome/CheckOutSuccess", request, cancellationToken);
            return;
        }

        public async Task<string> CreateCheckAsync(CreateCheckRequest request, CancellationToken cancellationToken)
        {
            var result = await _http.PostAsJsonAsync($"api/UserHome/CreateCheck", request, cancellationToken);
            var message = await result.Content.ReadAsStringAsync();
            return message;
        }

        public async Task<string> DeleteCheckAsync(Guid billId, CancellationToken cancellationToken)
        {
            var result = await _http.DeleteAsync($"api/UserHome/DeleteCheck?billId={billId}", cancellationToken);
            var message = await result.Content.ReadAsStringAsync();
            return message;
        }

        public async Task<List<UserHomeDto>> GetAllFilmForUserHome()
        {
            var result = await _http.GetFromJsonAsync<List<UserHomeDto>>($"api/UserHome/GetAllFilmForUserHome");
            return result;
        }

        public async Task<BillDetailDto> GetBillForCheckOut(Guid billId)
        {
            var result = await _http.GetFromJsonAsync<BillDetailDto>($"api/Bill/GetById?id={billId}");
            return result;
        }

        public async Task<int> GetPointOfMembershipAsync(Guid accountId, CancellationToken cancellationToken)
        {
            var response = await _http.GetAsync($"api/UserHome/GetPointOfMembership?accountId={accountId}", cancellationToken);
            var resultString = await response.Content.ReadAsStringAsync();
            var result = int.Parse(resultString);

            return result;
        }

        public async Task<bool> ResetDiscountAsync(Guid billId, CancellationToken cancellationToken)
        {
            var result = await _http.GetAsync($"api/UserHome/ResetDiscount?billId={billId}", cancellationToken);
            var message = await result.Content.ReadAsStringAsync();
            if (message == "true") return true;
            return false;
        }
    }
}