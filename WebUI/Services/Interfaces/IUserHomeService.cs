using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.UserHome;
using MovieTicket.Application.DataTransferObjs.UserHome.Requests;

namespace WebUI.Services.Interfaces
{
    public interface IUserHomeService
    {
        Task<List<UserHomeDto>> GetAllFilmForUserHome();

        Task<BillDetailDto> GetBillForCheckOut(Guid billId);

        Task<string> CreateCheckAsync(CreateCheckRequest request, CancellationToken cancellationToken);

        Task<string> AddComboToCheckAsync(ComboCheckRequest request, CancellationToken cancellationToken);

        Task<string> AddDiscountToCheckAsync(DiscountCheckRequest request, CancellationToken cancellationToken);

        Task<int> GetPointOfMembershipAsync(Guid accountId, CancellationToken cancellationToken);

        Task<string> DeleteCheckAsync(Guid billId, CancellationToken cancellationToken);

        Task CheckOutSuccessAsync(CheckOutSuccessRequest request, CancellationToken cancellationToken);

        Task<bool> ResetDiscountAsync(Guid billId, CancellationToken cancellationToken);

        Task SendMailForCheckOutAsync(Guid billId, CancellationToken cancellationToken);

        Task UpdateCheckMembershipIdAsync(Guid billId, string sdt, CancellationToken cancellationToken);
    }
}