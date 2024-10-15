using MovieTicket.Application.DataTransferObjs.SeatType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
	public interface ISeatTypeReadOnlyRepository
	{
		Task<IQueryable<SeatTypeDto>> GetAllAsync(CancellationToken cancellationToken);
	}
}
