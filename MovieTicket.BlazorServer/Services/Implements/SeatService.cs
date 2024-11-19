using MovieTicket.Application.DataTransferObjs.Seat;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
	public class SeatService : ISeatService
	{
		private readonly HttpClient _httpClient;

		public SeatService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IQueryable<SeatDTO>> GetSeats(Guid cinemaId)
		{
			var response = await _httpClient.GetAsync($"api/Seat/GetAll?CinemaId={cinemaId}");
			var result = await response.Content.ReadFromJsonAsync<List<SeatDTO>>();
			return result.AsQueryable();
		}

		public async Task<ResponseObject<SeatDTO>> GetById(Guid id)
		{
			var result = await _httpClient.GetFromJsonAsync<ResponseObject<SeatDTO>>($"api/Seat/GetById?id={id}");
			return result;
		}

		public async Task<ResponseObject<SeatDTO>> Create(SeatCreateRequest request)
		{
			var response = await _httpClient.PostAsJsonAsync("api/Seat/Create", request);
			var result = await response.Content.ReadFromJsonAsync<ResponseObject<SeatDTO>>();
			return result;
		}

		public async Task<ResponseObject<SeatDTO>> Update(SeatUpdateRequest request)
		{
			var response = await _httpClient.PutAsJsonAsync("api/Seat/Update", request);
			var result = await response.Content.ReadFromJsonAsync<ResponseObject<SeatDTO>>();
			return result;
		}

		public async Task<ResponseObject<SeatDTO>> Delete(Guid id)
		{
			var response = await _httpClient.DeleteAsync($"api/Seat/HardDelete?id={id}");
			var result = await response.Content.ReadFromJsonAsync<ResponseObject<SeatDTO>>();
			return result;
		}

		public async Task<ResponseObject<List<SeatDTO>>> UpdateRange(List<SeatUpdateRequest> request)
		{
			var response = await _httpClient.PutAsJsonAsync("api/Seat/UpdateRange", request);
			var result = await response.Content.ReadFromJsonAsync<ResponseObject<List<SeatDTO>>>();
			return result;
		}
	}
}