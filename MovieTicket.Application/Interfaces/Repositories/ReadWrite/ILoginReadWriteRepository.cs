using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Auth.Requests;
using static MovieTicket.Application.ValueObjs.ViewModels.CustomReponses;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
	public interface ILoginReadWriteRepository
	{
		Task<LoginRespone> LoginAsync(LoginDTO loginModel);

		LoginRespone RefreshToken(UserSession userSession);
	}
}