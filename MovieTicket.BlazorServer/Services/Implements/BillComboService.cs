using MovieTicket.Application.DataTransferObjs.BillCombo;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
	public class BillComboService : IBillComboService
	{
		private readonly HttpClient _httpClient;

		public BillComboService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<List<BillComboDto>> GetListBillComboByBillId(Guid billId)
		{
			var response = await _httpClient.GetFromJsonAsync<List<BillComboDto>>($"api/BillCombo/GetListBillComboByBillId?billId={billId}");
			return response;

		}
	}
}
