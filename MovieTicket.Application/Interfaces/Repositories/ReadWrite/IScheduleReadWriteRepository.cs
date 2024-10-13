using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.Application.DataTransferObjs.Schedule.Request;
using MovieTicket.Application.ValueObjs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IScheduleReadWriteRepository
    {
        Task<ResponseObject<ScheduleDto>> CreateAsync(CreateScheduleRequest createScheduleRequest);
        Task<ResponseObject<ScheduleDto>> UpdateAsync(UpdateScheduleRequest updateScheduleRequest);
        Task<ResponseObject<ScheduleDto>> DeleteAsync(Guid id);
    }
}
