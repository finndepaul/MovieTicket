using MovieTicket.Application.DataTransferObjs.UserHome;
using MovieTicket.BlazorServer.Services.Interfaces;
using MovieTicket.Domain.Enums;

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
			var result = await _http.GetFromJsonAsync<List<UserHomeDto>>($"https://localhost:44382/api/UserHome/GetAllFilmForUserHome");
			return result;
		}
	}
}
