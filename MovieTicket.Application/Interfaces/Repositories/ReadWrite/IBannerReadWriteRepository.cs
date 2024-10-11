using MovieTicket.Application.DataTransferObjs.Banner;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IBannerReadWriteRepository
    {
        Task<ResponseObject<BannerDTO>> Create(BannerCreateRequest banner);

        Task<ResponseObject<BannerDTO>> Update(BannerUpdateRequest banner);

        Task<ResponseObject<Banner>> HardDelete(Guid id);
    }
}