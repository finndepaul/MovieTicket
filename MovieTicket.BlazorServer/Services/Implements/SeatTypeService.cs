using MovieTicket.Application.DataTransferObjs.SeatType;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class SeatTypeService : ISeatTypeService
    {
        private readonly HttpClient _httpClient;

        public SeatTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SeatTypeDto>> GetListSeatTypesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SeatTypeDto>>("api/SeatType/GetListSeatTypes");
            return result;
        }
    }
}
