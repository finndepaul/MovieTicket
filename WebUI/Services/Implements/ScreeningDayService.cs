using MovieTicket.Application.DataTransferObjs.ScreeningDay;
using System.Net.Http.Json;
using WebUI.Services.Interfaces;

namespace WebUI.Services.Implements
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
