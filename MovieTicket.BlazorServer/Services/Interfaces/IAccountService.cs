using MovieTicket.Domain.Entities;
using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IQueryable<AccountDto>> GetAllAccount();

        Task<AccountDetail> GetAccountById(Guid Id, CancellationToken cancellationToken);

        Task<Account> Register(Account account);

        Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request, CancellationToken cancellationToken);

        Task<bool> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken);

        Task<ResponseObject<AccountDto>> CreateNewAccount(AccountCreateRequest request, CancellationToken cancellationToken);

        Task<ResponseObject<AccountDto>> UpdateAccount(AccountUpdateRequest request, CancellationToken cancellationToken);
    }
}