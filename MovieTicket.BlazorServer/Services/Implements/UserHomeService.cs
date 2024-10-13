using MovieTicket.Application.DataTransferObjs.UserHome;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class UserHomeService : IUserHomeService
    {
        private readonly HttpClient _http;

        public UserHomeService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<UserHomeDto>> GetAllFilmForUserHome()
        {
            var result = await _http.GetFromJsonAsync<List<UserHomeDto>>($"api/UserHome/GetAllFilmForUserHome");
            return result;
        }
    }
}