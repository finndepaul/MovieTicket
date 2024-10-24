using MovieTicket.Application.DataTransferObjs.CinemaType;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class CinemaTypeService : ICinemaTypeService
    {
        private readonly HttpClient _httpClient;

        public CinemaTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CinemaTypeDto>> GetListCinemaTypesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<CinemaTypeDto>>("api/CinemaType/GetListCinemaTypes");
            return result;
        }
    }
}
