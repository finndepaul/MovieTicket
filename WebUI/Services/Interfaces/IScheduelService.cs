using MovieTicket.Application.DataTransferObjs.Schedule.Request;
using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace WebUI.Services.Interfaces
{
    public interface IScheduelService
    {
        Task<PageList<ScheduleDto>> GetAllAsync(string? filmName, DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters, CancellationToken cancellationToken);

        Task<IQueryable<ScheduleDto>> GetAllAsync();

        Task<ScheduleDto> GetByIdAsync(Guid id);

        Task<IQueryable<FilmForCreateDto>> GetFilmAsync();

        Task<ResponseObject<ScheduleDto>> CreateAsync(CreateScheduleRequest createScheduleRequest, CancellationToken cancellationToken);

        Task<ResponseObject<ScheduleDto>> UpdateAsync(UpdateScheduleRequest updateScheduleRequest, CancellationToken cancellationToken);

        Task<ResponseObject<ScheduleDto>> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}