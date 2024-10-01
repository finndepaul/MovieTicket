using MovieTicket.Application.DataTransferObjs.UserHome;
using MovieTicket.Domain.Enums;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
	public interface IUserHomeService
	{
		Task<List<UserHomeDto>> GetAllFilmForUserHome();
	}
}
