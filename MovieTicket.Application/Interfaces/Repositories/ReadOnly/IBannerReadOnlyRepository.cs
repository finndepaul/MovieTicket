using MovieTicket.Application.DataTransferObjs.Banner;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IBannerReadOnlyRepository
    {
        Task<IQueryable<BannerDTO>> GetAllAsync();

        Task<ResponseObject<BannerDTO>> GetByIdAsync(Guid id);
    }
}