using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using MovieTicket.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class AccountPasswordRepository : IAccountPasswordRepository
    {
        private readonly MovieTicketReadWriteDbContext _db;

        public AccountPasswordRepository(MovieTicketReadWriteDbContext db)
        {
            _db = db;
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var account = await _db.Accounts.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (account != null)
            {
                if (Hash.DecryptPassword(account.Password) == request.OldPassword)
                {
                    account.Password = Hash.EncryptPassword(request.NewPassword);
                    await _db.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _db.ConfirmedEmails.FirstOrDefaultAsync(x => x.AccountId == request.AccountId && !x.IsConfirmed);
            var account = await _db.Accounts.FirstOrDefaultAsync(x => x.Id == request.AccountId);
            if (confirmEmail != null)
            {
                if (request.ConfirmPW.Trim() == confirmEmail.ConfirmCode)
                {
                    account.Password = Hash.EncryptPassword(request.NewPassword);
                    confirmEmail.IsConfirmed = true;
                    _db.ConfirmedEmails.Update(confirmEmail);
                    _db.Accounts.Update(account);
                   await _db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
