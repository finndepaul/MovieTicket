using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.DataTransferObjs.Auth.Requests;
using static MovieTicket.Application.ValueObjs.ViewModels.CustomReponses;

namespace WebUI.Services.Interfaces
{
    public interface IAuthenService
    {
        Task<LoginRespone> LoginAsync(LoginDTO loginModel);

        Task<RegisterResponse> RegisterAsync(AccountRegisterRequest registerModel);

        Task<LoginRespone> RefreshToken(UserSession session);

        Task Logout();
    }
}