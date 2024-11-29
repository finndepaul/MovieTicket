using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IEmailSenderReadWriteRepository
    {
        Task<ResponseObject<Guid>> SendEmail(string email, EmailType type, CancellationToken cancellationToken);
    }
}