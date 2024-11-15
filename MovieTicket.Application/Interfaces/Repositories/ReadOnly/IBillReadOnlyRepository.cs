using MovieTicket.Application.DataTransferObjs.Bill;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
	public interface IBillReadOnlyRepository
	{
		Task<IQueryable<BillDto>> GetAllAsync();

		Task<BillDetailDto?> GetByIdAsync(Guid Id);
	}
}