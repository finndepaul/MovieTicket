using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface ICinemaCenterService
    {
        Task<IQueryable<CinemaCenterDto>> GetCinemaCentersAsync(CinemaCenterSearch search);
        Task<PageList<CinemaCenterDto>> GetAllCinemaCenter(CinemaCenterSearch search, PagingParameters pagingParameters);
        Task<ResponseObject<CinemaCenterDto>> GetCinemaCenterById(Guid id);
        Task<ResponseObject<CinemaCenter>> Create(CinemaCenterCreateRequest cinemaCenter);
        Task<ResponseObject<CinemaCenter>> Update(Guid Id, CinemaCenterUpdateRequest cinemaCenter);
        Task<ResponseObject<CinemaCenter>> Delete(Guid id);
    }
}