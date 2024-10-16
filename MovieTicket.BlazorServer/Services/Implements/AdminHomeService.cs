using MovieTicket.Application.DataTransferObjs.AdminHome;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class AdminHomeService : IAdminHomeService
	{
		private readonly HttpClient _httpClient;

		public AdminHomeService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<GeneralDto> GetAdminGeneralAsync()
		{
			var result = await _httpClient.GetFromJsonAsync<GeneralDto>("api/AdminHome/GetAdminGeneral");
			return result;
		}

		public async Task<List<RevenueByCinemaDto>> GetListRevenueByCinemaAsync(DateTime? startDate, DateTime? endDate)
		{
			var result = await _httpClient.GetFromJsonAsync<List<RevenueByCinemaDto>>($"api/AdminHome/GetListRevenueByCinema?startDate={startDate}&endDate={endDate}");
			return result;
		}

		public async Task<List<RevenueByMovieDto>> GetListRevenueByMovieAsync(DateTime? startDate, DateTime? endDate)
		{
			var result = await _httpClient.GetFromJsonAsync<List<RevenueByMovieDto>>($"api/AdminHome/GetListRevenueByMovie?startDate={startDate}&endDate={endDate}");
			return result;
		}
	}
}
