using MovieTicket.Application.DataTransferObjs.ScreenType;
using MovieTicket.BlazorServer.Services.Interfaces.IScreenTypeService;
using System.Net.Http;

namespace MovieTicket.BlazorServer.Services.Implements.ScreenTypeService
{
    public class ScreenTypeService : IScreenTypeService
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
