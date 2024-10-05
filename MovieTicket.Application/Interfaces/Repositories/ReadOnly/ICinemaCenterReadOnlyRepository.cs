using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface ICinemaCenterReadOnlyRepository
    {
        Task<IQueryable<CinemaCenterDto>> GetAll(CinemaCenterSearch search);

        Task<ResponseObject<CinemaCenter>> GetById(Guid id);
    }
}