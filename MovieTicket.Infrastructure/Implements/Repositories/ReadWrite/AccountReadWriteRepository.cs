using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class AccountReadWriteRepository : IAccountReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _db;
        public AccountReadWriteRepository(MovieTicketReadWriteDbContext db)
        {
            _db = db;
        }
        public async Task<ResponseObject<Account>> Register(Account account)
        {
            var accountItem = await _db.Accounts.FirstOrDefaultAsync(x=> x.Email == account.Email || x.Phone == account.Phone);
            if (accountItem != null)
            {
                return new ResponseObject<Account>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Account is exist",
                    Data = null
                };
            }
            account.CreateDate = DateTime.Now;
            account.Role = AccountRole.User;
            account.Status = AccountStatus.Active;
            await _db.Accounts.AddAsync(account);
            await _db.SaveChangesAsync();
            return new ResponseObject<Account> 
            {
                Status = StatusCodes.Status200OK,
                Message = "Register success",
                Data = account
            };
        }
    }

}
