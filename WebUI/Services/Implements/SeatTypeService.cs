using MovieTicket.Application.DataTransferObjs.SeatType;
using System.Net.Http.Json;
using WebUI.Services.Interfaces;

namespace WebUI.Services.Implements
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
