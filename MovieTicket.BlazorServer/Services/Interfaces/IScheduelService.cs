using MovieTicket.Application.DataTransferObjs.Schedule.Request;
using MovieTicket.Application.DataTransferObjs.Schedule;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IScheduelService
    {
        Task<IQueryable<ScheduleDto>> GetAllAsync();
        Task<ScheduleDto> GetByIdAsync(Guid id);
        Task<IQueryable<FilmForCreateDto>> GetFilmAsync();
        Task<bool> CreateAsync(CreateScheduleRequest createScheduleRequest);
        Task<bool> UpdateAsync(UpdateScheduleRequest updateScheduleRequest);
        Task<bool> DeleteAsync(Guid id);
    }
}
