using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.ValueObjs.Paginations;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IBillService
    {
        Task<List<BillDto>> GetListBillAsync();
        Task<BillDetailDto> GetBillByIdAsync(Guid billId);
		Task<PageList<BillsDto>> GetListBillWithPaginationAsync(BillWithPaginationRequest request, PagingParameters pagingParameters);
	}
}
