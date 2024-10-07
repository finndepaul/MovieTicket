using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using static MovieTicket.Application.ValueObjs.ViewModels.CustomReponses;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IAccountReadWriteRepository
    {
        //Task<ResponseObject<Account>> Register(Account account);
        Task<RegisterResponse> RegisterAsync(Account account);

        Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request, CancellationToken cancellationToken);

        Task<bool> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken);

        Task<ResponseObject<AccountDto>> CreateNewAccount(AccountCreateRequest request, CancellationToken cancellationToken);

        Task<ResponseObject<AccountDto>> UpdateAccount(AccountUpdateRequest request, CancellationToken cancellationToken);
    }
}