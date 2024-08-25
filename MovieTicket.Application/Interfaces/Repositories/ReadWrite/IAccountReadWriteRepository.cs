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
    }
}
