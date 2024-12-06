using MovieTicket.Application.DataTransferObjs.About;

namespace WebUI.Services.Interfaces
{
    public interface IAboutService
    {
        Task<IEnumerable<AboutDto>> GetAllAsync();
        Task<AboutDto> GetByIdAsync(Guid Id);
        Task<AboutDto> CreateAsync(CreateAboutDto createAboutDto);
        Task<AboutDto> UpdateAsync(Guid Id, UpdateAboutDto updateAboutDto);
        Task<AboutDto> DeleteAsync(Guid id);
    }
}
