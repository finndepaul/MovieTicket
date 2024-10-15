using MovieTicket.Application.DataTransferObjs.ScreeningDay;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
	public class ScreeningDayService : IScreeningDayService
	{
		private readonly HttpClient _httpClient;

		public ScreeningDayService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<ScreeningDayDto>> GetListScreeningDaysAsync()
		{
			var result = await _httpClient.GetFromJsonAsync<List<ScreeningDayDto>>("api/ScreeningDay/GetListScreeningDays");
			return result;
		}
	}
}
