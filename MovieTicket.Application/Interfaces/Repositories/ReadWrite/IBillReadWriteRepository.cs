using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IBillReadWriteRepository
    {
        Task<ResponseObject<BillDto>> CreateAsync(CreateBillRequest createBillRequest);

        Task<ResponseObject<BillDto>?> UpdateAsync(Guid id, UpdateBillRequest updateBillRequest);

        Task<ResponseObject<BillDto>?> DeleteAsync(Guid id);

		Task<ResponseObject<bool>?> UpdateStatusAsync(Guid id, BillStatus status);
	}
}