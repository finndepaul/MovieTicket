using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface ICinemaCenterService
    {
        Task<IQueryable<CinemaCenterDto>> GetCinemaCentersAsync(CinemaCenterSearch search);

        Task<ResponseObject<CinemaCenterDto>> GetCinemaCenterById(Guid id);
    }
}