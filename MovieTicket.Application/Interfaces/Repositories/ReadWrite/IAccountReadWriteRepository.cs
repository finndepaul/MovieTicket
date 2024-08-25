using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IAccountReadWriteRepository
    {
        Task<ResponseObject<Account>> Register(Account account);
        Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request, CancellationToken cancellationToken);
        Task<bool> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken);
        Task<ResponseObject<AccountDto>> CreateNewAccount(AccountCreateRequest request, CancellationToken cancellationToken);
        Task<ResponseObject<AccountDto>> UpdateAccount(AccountUpdateRequest request, CancellationToken cancellationToken);
    }
}
