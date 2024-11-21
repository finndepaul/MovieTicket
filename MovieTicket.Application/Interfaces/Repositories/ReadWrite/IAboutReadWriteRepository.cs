using MovieTicket.Application.DataTransferObjs.About;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IAboutReadWriteRepository
    {
        Task<AboutDto> CreateAsync(CreateAboutDto createAboutDto);
        Task<AboutDto> UpdateAsync(Guid Id, UpdateAboutDto updateAboutDto);
        Task<AboutDto> DeleteAsync(Guid Id);
    }
}
