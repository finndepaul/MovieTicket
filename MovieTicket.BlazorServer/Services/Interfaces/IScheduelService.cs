using MovieTicket.Application.DataTransferObjs.Schedule.Request;
using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.Application.ValueObjs.Paginations;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IScheduelService
    {
        Task<PageList<ScheduleDto>> GetAllAsync(string? filmName, DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters, CancellationToken cancellationToken);

        Task<IQueryable<ScheduleDto>> GetAllAsync();

        Task<ScheduleDto> GetByIdAsync(Guid id);

        Task<IQueryable<FilmForCreateDto>> GetFilmAsync();

        Task<bool> CreateAsync(CreateScheduleRequest createScheduleRequest, CancellationToken cancellationToken);

        Task<bool> UpdateAsync(UpdateScheduleRequest updateScheduleRequest, CancellationToken cancellationToken);

        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}