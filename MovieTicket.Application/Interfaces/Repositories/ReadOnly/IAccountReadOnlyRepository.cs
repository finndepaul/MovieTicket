using MovieTicket.Application.DataTransferObjs.Account;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IAccountReadOnlyRepository
    {
        Task<IQueryable<AccountDto>> GetAllAccount();

        Task<AccountDetail> GetAccountById(Guid Id, CancellationToken cancellationToken);
    }
}