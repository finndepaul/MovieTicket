using MovieTicket.Application.DataTransferObjs.UserHome.Requests;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
	public interface IUserHomeReadWriteRepository
	{
		Task<string> CreateCheckAsync(CreateCheckRequest request, CancellationToken cancellationToken);

		Task<string> AddComboToCheckAsync(ComboCheckRequest request, CancellationToken cancellationToken);

		Task<string> AddDiscountToCheckAsync(DiscountCheckRequest request, CancellationToken cancellationToken);

		Task<string> DeleteCheckAsync(Guid billId, CancellationToken cancellationToken);

		Task<string> CheckOutSuccessAsync(Guid billId, CancellationToken cancellationToken);
	}
}