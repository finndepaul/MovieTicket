using MovieTicket.Application.DataTransferObjs.Cinema;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface ICinemaService
    {
        Task<List<CinemaDto>> GetCinemasAsync(string? name);

        Task<ResponseObject<CinemaDto>> GetCinemaById(Guid id);
    }
}