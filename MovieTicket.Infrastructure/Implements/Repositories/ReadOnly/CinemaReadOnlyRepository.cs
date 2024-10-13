using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Cinema;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class CinemaReadOnlyRepository : ICinemaReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _dbContext;

        public CinemaReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<CinemaDto>> GetAllAsync(string? name)
        {
            var query = _dbContext.Cinemas.Select(c => new CinemaDto
            {
                Id = c.Id,
                Name = c.Name,
                CinemaTypeName = c.CinemaType.Name,
                CinemaCenterName = c.CinemaCenter.Name,
                MaxSeatCapacity = c.MaxSeatCapacity,
                Column = c.Column,
                Row = c.Row,
                Description = c.Description,
                CreateTime = c.CreateTime,
                UpdateTime = c.UpdateTime
            }).AsNoTracking();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Name == name);
            }
            return query.AsQueryable();
        }

        //public async Task<IQueryable<CinemaDto>> GetAllCinemasByCenterName(string name, CancellationToken cancellationToken)
        //{
        //    return _dbContext.Cinemas.Where(x => x.CinemaCenter.Name == name).Select(c => new CinemaDto
        //    {
        //        Id = c.Id,
        //        Name = c.Name,
        //        CinemaTypeName = c.CinemaType.Name,
        //        CinemaCenterName = c.CinemaCenter.Name,
        //        MaxSeatCapacity = c.MaxSeatCapacity,
        //        Column = c.Column,
        //        Row = c.Row,
        //        Description = c.Description,
        //        CreateTime = c.CreateTime
        //    }).AsNoTracking();
        //}

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
                CreateTime = result.CreateTime,
                UpdateTime = result.UpdateTime
            };
        }
    }
}