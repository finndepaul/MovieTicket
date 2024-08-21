using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IEmailSenderReadWriteRepository
    {
        Task<bool> SendEmail(string email, EmailType type, CancellationToken cancellationToken);
    }
}
