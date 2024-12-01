using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Enums;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IAccountUtilitiesService
    {
        Task<bool> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken);

		Task<ResponseObject<bool>> ForgotPasswordAsync(ForgotPasswordRequest request);

		Task<ResponseObject<Guid>> SendEmail(string email, EmailType type);


	}
}
