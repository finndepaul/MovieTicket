using MovieTicket.Application.DataTransferObjs.ScreenType;
using System.Net.Http.Json;
using WebUI.Services.Interfaces;

namespace WebUI.Services.Implements
{
    public class ScreenTypeServices : IScreenTypeServices
    {
        private readonly HttpClient _httpClient;

        public ScreenTypeServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ScreenTypeDto>> GetAllScreenTypes()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ScreenTypeDto>>("api/ScreenType/GetAll");
            return result;
        }
    }
}
