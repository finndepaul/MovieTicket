using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Enums;

namespace WebUI.Services.Interfaces
{
    public interface IBillService
    {
        Task<List<BillDto>> GetListBillAsync();
        Task<BillDetailDto> GetBillByIdAsync(Guid billId);
		Task<PageList<BillsDto>> GetListBillWithPaginationAsync(BillWithPaginationRequest request, PagingParameters pagingParameters);
		Task<ResponseObject<bool>?> UpdateStatusAsync(Guid id, BillStatus status);
	}
}
