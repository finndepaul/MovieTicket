using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IScheduleReadWriteRepository
    {
        Task<ResponseObject<ScheduleDto>> CreateAsync(CreateScheduleRequest createScheduleRequest);

        Task<ResponseObject<ScheduleDto?>> UpdateAsync(Guid id, UpdateScheduleRequest updateScheduleRequest);

        Task<ResponseObject<ScheduleDto?>> DeleteAsync(Guid id);
    }
}