using MovieTicket.Application.DataTransferObjs.ScreenType;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
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
