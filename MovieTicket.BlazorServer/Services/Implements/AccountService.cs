using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.BlazorServer.Services.Interfaces;
using MovieTicket.Domain.Entities;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class AccountService : IAccountService
    {
        public Task<bool> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<AccountDto>> CreateNewAccount(AccountCreateRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AccountDetail> GetAccountById(Guid Id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<AccountDto>> GetAllAccount()
        {
            throw new NotImplementedException();
        }

        public Task<Account> Register(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseObject<AccountDto>> UpdateAccount(AccountUpdateRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}