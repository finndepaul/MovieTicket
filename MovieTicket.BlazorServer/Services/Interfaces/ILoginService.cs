using Microsoft.AspNetCore.Identity.Data;
using MovieTicket.Application.DataTransferObjs.Auth;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface ILoginService
    {
        Task<ResponseObject<LoginDto>> Login(LoginRequest loginRequest, CancellationToken cancellationToken);
    }
}