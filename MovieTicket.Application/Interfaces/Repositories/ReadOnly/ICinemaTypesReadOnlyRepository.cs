using MovieTicket.Application.DataTransferObjs.CinemaType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
	public interface ICinemaTypesReadOnlyRepository
	{
		Task<IQueryable<CinemaTypeDto>> GetAllAsync();
	}
}
