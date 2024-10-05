using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IEmailSenderReadWriteRepository
    {
        Task<bool> SendEmail(string email, EmailType type, CancellationToken cancellationToken);
    }
}