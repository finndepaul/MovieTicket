using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface ICinemaCenterReadWriteRepository
    {
        Task<ResponseObject<CinemaCenter>> Create(CinemaCenter cinemaCenter);

        Task<ResponseObject<CinemaCenter>> Update(Guid Id, CinemaCenterUpdateRequest cinemaCenter);

        Task<ResponseObject<CinemaCenter>> Delete(Guid id);
    }
}