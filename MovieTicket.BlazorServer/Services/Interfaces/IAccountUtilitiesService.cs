using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Domain.Enums;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IAccountUtilitiesService
    {
        Task<bool> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken);
        
    }
}
