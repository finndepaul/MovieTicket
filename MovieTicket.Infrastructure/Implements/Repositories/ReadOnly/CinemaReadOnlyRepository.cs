using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Cinema;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class CinemaReadOnlyRepository : ICinemaReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _dbContext;

        public CinemaReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<CinemaDto>> GetAllAsync()
        {
            return _dbContext.Cinemas.Select(c => new CinemaDto
            {
                Id = c.Id,
                Name = c.Name,
                CinemaTypeName = c.CinemaType.Name,
                CinemaCenterName = c.CinemaCenter.Name,
                MaxSeatCapacity = c.MaxSeatCapacity,
                Column = c.Column,
                Row = c.Row,
                Description = c.Description,
                CreateTime = c.CreateTime
            }).AsNoTracking();
        }

        public async Task<CinemaDto> GetCinemaById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Cinemas.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (result == null)
            {
                return null;
            }
            return new CinemaDto
            {
                Id = result.Id,
                Name = result.Name,
                CinemaTypeName = _dbContext.CinemaTypes.FirstOrDefaultAsync(x => x.Id == result.CinemaTypeId).Result.Name,
                CinemaCenterName = _dbContext.CinemaCenters.FirstOrDefaultAsync(x => x.Id == result.CinemaCenterId).Result.Name,
                MaxSeatCapacity = result.MaxSeatCapacity,
                Column = result.Column,
                Row = result.Row,
                Description = result.Description,
                CreateTime = result.CreateTime
            };
        }
    }
}
