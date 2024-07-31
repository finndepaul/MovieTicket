
using MovieTicket.Application.DataTransferObjs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IAccountPasswordRepository
    {
        Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request,CancellationToken cancellationToken);
        Task<bool> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken);
    }
}
