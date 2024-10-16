using MovieTicket.Application.DataTransferObjs.ScreenType;

using System.Net.Http;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class ScreenTypeService : IScreenTypeServices
    {
        private readonly HttpClient _httpClient;

        public ScreenTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ScreenTypeDto>> GetAllScreenTypes()
        {
            return await _httpClient.GetFromJsonAsync<List<ScreenTypeDto>>("api/ScreenType/GetAll");
        }
    }
}
