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
		Task<ResponseObject<ScheduleDto>> CreateAsync(CreateScheduleRequest request, CancellationToken cancellationToken);

		Task<ResponseObject<ScheduleDto>> UpdateAsync(UpdateScheduleRequest request, CancellationToken cancellationToken);

		Task<ResponseObject<ScheduleDto>> DeleteAsync(Guid id, CancellationToken cancellationToken);
	}
}