using MovieTicket.Application.DataTransferObjs.About;
using System.Net.Http.Json;
using WebUI.Services.Interfaces;

namespace WebUI.Services.Implements
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<AboutDto> CreateAsync(CreateAboutDto createAboutDto)
        {
            var result = await _httpClient.PostAsJsonAsync("api/About/Create", createAboutDto);
            return await result.Content.ReadFromJsonAsync<AboutDto>();
        }

        public async Task<AboutDto> DeleteAsync(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/About/Delete?Id={id}");
            return await result.Content.ReadFromJsonAsync<AboutDto>();
        }

        public async Task<IEnumerable<AboutDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<AboutDto>>("api/About/GetAll");
        }

        public async Task<AboutDto> GetByIdAsync(Guid Id)
        {
            var about = await _httpClient.GetFromJsonAsync<AboutDto>($"api/About/GetById?Id={Id}");
            return about;
        }

        public async Task<AboutDto> UpdateAsync(Guid Id, UpdateAboutDto updateAboutDto)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/About/Update?Id={Id}", updateAboutDto);
            return await result.Content.ReadFromJsonAsync<AboutDto>();
        }
    }
}
