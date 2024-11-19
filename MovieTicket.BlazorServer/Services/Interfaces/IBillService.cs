using MovieTicket.Application.DataTransferObjs.Bill;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IBillService
    {
        Task<List<BillDto>> GetListBillAsync();
        Task<BillDetailDto> GetBillByIdAsync(Guid billId);
	}
}
