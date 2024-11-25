using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.Application.ValueObjs.Paginations;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IScheduleReadOnlyRepository
    {
        Task<IQueryable<ScheduleDto>> GetAllAsync();

        Task<PageList<ScheduleDto>> GetAllPagingAsync(string? filmName, DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters, CancellationToken cancellationToken);

        Task<ScheduleDto> GetByIdAsync(Guid id);

        Task<IQueryable<ScheduleDto>> GetByFilmIdAsync(Guid filmId);

        Task<IQueryable<FilmForCreateDto>> GetFilmForCreateAsync();
    }
}