using MovieTicket.Application.DataTransferObjs.ScreeningDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
	public interface IScreeningDayReadOnlyRepository
	{
		Task<IQueryable<ScreeningDayDto>> GetAllAsync(CancellationToken cancellationToken);
	}
}
