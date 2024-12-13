using MovieTicket.Application.DataTransferObjs.Banner;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace WebUI.Services.Interfaces
{
    public interface IBannerService
    {
        Task<List<BannerDTO>> GetBannersAsync();

        Task<ResponseObject<BannerDTO>> Create(BannerCreateRequest banner);

        Task<ResponseObject<BannerDTO>> Update(BannerUpdateRequest banner);

        Task<ResponseObject<BannerDTO>> GetById(Guid id);

        Task<ResponseObject<BannerDTO>> Delete(Guid id);
    }
}