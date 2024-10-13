using MovieTicket.Application.DataTransferObjs.Cinema;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class CinemaService : ICinemaService
    {
        private readonly HttpClient _httpClient;

        public CinemaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseObject<CinemaDto>> GetCinemaById(Guid id)
        {
            var respone = await _httpClient.GetFromJsonAsync<ResponseObject<CinemaDto>>($"https://localhost:6868/api/Cinema/GetById?id={id}");
            return respone;
        }

        public async Task<List<CinemaDto>> GetCinemasAsync(string? name)
        {
            var result = await _httpClient.GetFromJsonAsync<List<CinemaDto>>($"https://localhost:6868/api/Cinema/GetAll?name={name}");
            return result;
        }
    }
}