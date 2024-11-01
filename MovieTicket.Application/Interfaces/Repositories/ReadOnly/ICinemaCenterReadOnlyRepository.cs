using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface ICinemaCenterReadOnlyRepository
    {
        Task<IQueryable<CinemaCenterDto>> GetAll(CinemaCenterSearch search);
		Task<PageList<CinemaCenterDto>> GetAllCinemaCenter(CinemaCenterSearch search, PagingParameters pagingParameters);
		Task<ResponseObject<CinemaCenterDto>> GetById(Guid id);
    }
}