using Azure;
using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
	public class TicketPriceService : ITicketPriceService
	{
		private readonly HttpClient _http;

		public TicketPriceService(HttpClient http)
		{
			_http = http;
		}

		public async Task<ResponseObject<TicketPriceCreateRequest>> Create(TicketPriceCreateRequest request)
		{
			var result = await _http.PostAsJsonAsync("api/TicketPrice/CreateTicketPrice", request);
			var readObj = await result.Content.ReadFromJsonAsync<ResponseObject<TicketPriceCreateRequest>>();
			return new ResponseObject<TicketPriceCreateRequest>()
			{
				Data = readObj.Data,
				Message = readObj.Message,
				Status = readObj.Status
			};
		}

		public async Task<ResponseObject<bool>> Delete(Guid id)
		{
			var result = await _http.DeleteAsync($"api/TicketPrice/DeleteTicketPrice?id={id}");
			var readObj = await result.Content.ReadFromJsonAsync<ResponseObject<bool>>();
			return new ResponseObject<bool>()
			{
				Data = readObj.Data,
				Message = readObj.Message,
				Status = readObj.Status
			};
		}

		public async Task<List<TicketPriceDto>> GetAllAsync()
		{
			var result = await _http.GetFromJsonAsync<List<TicketPriceDto>>("api/TicketPrice/GetListTicketPrice");
			return result;
		}

		public async Task<TicketPriceDto> GetByIdAsync(Guid Id)
		{
			var result = await _http.GetFromJsonAsync<TicketPriceDto>($"api/TicketPrice/GetTicketPrice?id={Id}");
			return result;
		}

		public async Task<ResponseObject<TicketPriceUpdateRequest>> Update(TicketPriceUpdateRequest request)
		{
			var result = await _http.PutAsJsonAsync("api/TicketPrice/UpdateTicketPrice", request);
			var readObj = await result.Content.ReadFromJsonAsync<ResponseObject<TicketPriceUpdateRequest>>();
			return new ResponseObject<TicketPriceUpdateRequest>()
			{
				Data = readObj.Data,
				Message = readObj.Message,
				Status = readObj.Status
			};
		}
	}
}
