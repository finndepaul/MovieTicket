using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Coupon;
using MovieTicket.Application.ValueObjs.Paginations;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IAccountReadOnlyRepository
    {
        Task<IQueryable<AccountDto>> GetAllAccount();

        Task<AccountDto> GetAccountById(Guid Id, CancellationToken cancellationToken);

        Task<PageList<AccountDto>> GetAllAccPaging(PagingParameters pagingParameters);
        Task<PageList<CouponDto>> GetUserCouponUsageHistoryAsync(Guid userId, PagingParameters pagingParameters, CancellationToken cancellationToken);
        Task<int> GetMembershipPointsAsync(Guid userId, CancellationToken cancellationToken); // New method

    }
}