using MovieTicket.Application.DataTransferObjs.UserHome;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IUserHomeService
    {
        Task<List<UserHomeDto>> GetAllFilmForUserHome();
    }
}