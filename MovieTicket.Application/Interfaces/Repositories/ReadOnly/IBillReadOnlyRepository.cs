using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.ValueObjs.Paginations;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
	public interface IBillReadOnlyRepository
	{
		Task<IQueryable<BillDto>> GetAllAsync();
		Task<PageList<BillsDto>> GetListBillWithPaginationAsync(BillWithPaginationRequest request, PagingParameters pagingParameters,CancellationToken cancellationToken);
		Task<BillDetailDto?> GetByIdAsync(Guid Id);
        Task<PageList<BillsDto>> GetUserBookingHistoryAsync(Guid userId, PagingParameters pagingParameters, CancellationToken cancellationToken);

    }
}