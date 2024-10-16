using MovieTicket.Application.DataTransferObjs.Cinema;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface ICinemaService
    {
        Task<IQueryable<CinemaDto>> GetCinemasAsync(string? cinemaCenterName, string? name);

        Task<ResponseObject<CinemaDto>> GetCinemaById(Guid id);
    }
}