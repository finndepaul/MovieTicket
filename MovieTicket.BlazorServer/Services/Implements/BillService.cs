using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class BillService : IBillService
    {
        private readonly HttpClient _http;

        public BillService(HttpClient http)
        {
            _http = http;
        }

		public async Task<BillDetailDto> GetBillByIdAsync(Guid billId)
		{
			var response = await _http.GetFromJsonAsync<BillDetailDto>($"api/Bill/GetById?id={billId}");
			return response;
		}

		public async Task<List<BillDto>> GetListBillAsync()
        {
            var response = await _http.GetFromJsonAsync<List<BillDto>>("api/Bill/GetAll");
            return response;
        }
    }
}
