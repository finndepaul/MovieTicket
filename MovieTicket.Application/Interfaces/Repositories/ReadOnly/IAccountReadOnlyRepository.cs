using MovieTicket.Application.DataTransferObjs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IAccountReadOnlyRepository
    {
        Task<IQueryable<AccountDto>> GetAllAccount();
        Task<AccountDetail> GetAccountById(Guid Id, CancellationToken cancellationToken);
    }
}
