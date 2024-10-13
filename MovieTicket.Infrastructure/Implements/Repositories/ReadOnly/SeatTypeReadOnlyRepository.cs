using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.SeatType;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
	public class SeatTypeReadOnlyRepository : ISeatTypeReadOnlyRepository
	{
		private readonly MovieTicketReadOnlyDbContext _dbContext;

		public SeatTypeReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IQueryable<SeatTypeDto>> GetAllAsync(CancellationToken cancellationToken)
		{
			var seatTypesModel = await _dbContext.SeatTypes.AsNoTracking().ToListAsync();
			if (!seatTypesModel.Any())
			{
				throw new InvalidOperationException("No seat types found.");
			}
			var seatTypeDtos = seatTypesModel.Select(s => new SeatTypeDto
			{
				Id = s.Id,
				Name = s.Name
			});
			return seatTypeDtos.AsQueryable();
		}
	}
}
