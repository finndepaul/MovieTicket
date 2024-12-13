using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.Coupon;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace WebUI.Services.Interfaces
{
    public interface IAccountService
    {
        Task<PageList<AccountDto>> GetAllAccPaginition(PagingParameters pagingParameters);
        Task<IEnumerable<AccountDto>> GetAllAsync();
        Task<AccountDto> GetByIdAsync(Guid id);
        Task<ResponseObject<AccountDto>> CreateAsync(AccountCreateRequest accountCreateRequest);
        Task<AccountDto> UpdateAsync(AccountUpdateRequest accountUpdateRequest);
        Task<bool> UpdateStatusAccount(Guid id);
        Task<PageList<CouponDto>> GetUserCouponUsageHistoryAsync(Guid userId, PagingParameters pagingParameters, CancellationToken cancellationToken);
        Task<int> GetMembershipPointsAsync(Guid userId, CancellationToken cancellationToken); 
        Task<PageList<BillsDto>> GetUserBookingHistoryAsync(Guid userId, PagingParameters pagingParameters);
    }
}
