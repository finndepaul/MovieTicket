using MovieTicket.Application.DataTransferObjs.Schedule;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IScheduleReadOnlyRepository
    {
        Task<IQueryable<ScheduleDto>> GetAllAsync();

        Task<ScheduleDto?> GetByIdAsync(Guid id);

        Task<IQueryable<ScheduleDto>> GetByFilmIdAsync(Guid filmId);
    }
}