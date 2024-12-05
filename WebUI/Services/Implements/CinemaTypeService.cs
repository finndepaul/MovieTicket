using MovieTicket.Application.DataTransferObjs.CinemaType;
using System.Net.Http.Json;
using WebUI.Services.Interfaces;

namespace WebUI.Services.Implements
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
