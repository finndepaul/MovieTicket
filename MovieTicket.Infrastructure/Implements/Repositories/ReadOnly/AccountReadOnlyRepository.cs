using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class AccountReadOnlyRepository : IAccountReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _context;

        public AccountReadOnlyRepository(MovieTicketReadOnlyDbContext context)
        {
            _context = context;
        }

        public async Task<AccountDetail> GetAccountById(Guid Id, CancellationToken cancellationToken)
        {
            var model = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
            return new AccountDetail
            {
                Avatar = model.Avatar,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Role = model.Role,
                Status = model.Status,
            };
        }

        public async Task<IQueryable<AccountDto>> GetAllAccount()
        {
            return _context.Accounts
                .Select(x => new AccountDto
                {
                    Id = x.Id,
                    Username = x.Username,
                    Avatar = x.Avatar,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Role = x.Role,
                    Status = x.Status,
                    CreateDate = x.CreateDate
                })
                .AsNoTracking();
        }
    }
}
