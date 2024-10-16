using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.ScreeningDay;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
	public class ScreeningDayReadOnlyRepository : IScreeningDayReadOnlyRepository
	{
		private readonly MovieTicketReadOnlyDbContext _dbContext;

		public ScreeningDayReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IQueryable<ScreeningDayDto>> GetAllAsync(CancellationToken cancellationToken)
		{
			var screeningDaysModel = await _dbContext.ScreeningDays.AsNoTracking().ToListAsync();
			if (!screeningDaysModel.Any())
			{
				throw new InvalidOperationException("No screening days found.");
			}
			var screeningDayDtos = screeningDaysModel.Select(s => new ScreeningDayDto
			{
				Id = s.Id,
				Day = s.Day
			});
			return screeningDayDtos.AsQueryable();
		}
	}
}
