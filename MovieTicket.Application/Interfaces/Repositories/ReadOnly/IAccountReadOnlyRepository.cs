using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.ValueObjs.Paginations;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IAccountReadOnlyRepository
    {
        Task<IQueryable<AccountDto>> GetAllAccount();

        Task<AccountDetail> GetAccountById(Guid Id, CancellationToken cancellationToken);

        Task<PageList<AccountDto>> GetAllAccPaging(PagingParameters pagingParameters);
    }
}