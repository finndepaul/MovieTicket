using MovieTicket.Application.DataTransferObjs.About;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IAboutReadOnlyRepository
    {
        Task<IQueryable<AboutDto>> GetAllAsync();
        Task<AboutDto> GetByIdAsync(Guid Id);
    }
}
