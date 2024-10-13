using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.CinemaType;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
	public class CinemaTypesReadOnlyRepository : ICinemaTypesReadOnlyRepository
	{
		private readonly MovieTicketReadOnlyDbContext _dbContext;

		public CinemaTypesReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IQueryable<CinemaTypeDto>> GetAllAsync()
		{
			var cinemaTypesModel = await _dbContext.CinemaTypes.AsNoTracking().ToListAsync();
			if (!cinemaTypesModel.Any())
			{
				throw new InvalidOperationException("No cinema types found.");
			}
			var cinemaTypeDtos = cinemaTypesModel.Select(c => new CinemaTypeDto
			{
				Id = c.Id,
				Name = c.Name
			});
			return cinemaTypeDtos.AsQueryable();
		}
	}
}
