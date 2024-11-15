using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.UserHome;
using MovieTicket.Application.DataTransferObjs.UserHome.Requests;
using MovieTicket.BlazorServer.Services.Interfaces;
using MovieTicket.Domain.Entities;

namespace MovieTicket.BlazorServer.Services.Implements
{
	public class UserHomeService : IUserHomeService
	{
		private readonly HttpClient _http;

		public UserHomeService(HttpClient http)
		{
			_http = http;
		}

		public async Task<string> CheckOutSuccessAsync(Guid billId, CancellationToken cancellationToken)
		{
			var result = await _http.PutAsJsonAsync($"api/UserHome/CheckOutSuccess", billId, cancellationToken);
			var message = await result.Content.ReadAsStringAsync();
			return message;
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

		public async Task<string> UpdateCheckAsync(UpdateCheckRequest request, CancellationToken cancellationToken)
		{
			var result = await _http.PutAsJsonAsync($"api/UserHome/UpdateCheck", request, cancellationToken);
			var message = await result.Content.ReadAsStringAsync();
			return message;
		}
	}
}