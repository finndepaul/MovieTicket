using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Cinema;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.ViewModels;
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

		public async Task<IQueryable<CinemaDto>> GetAll()
		{
			var query = await _dbContext.Cinemas.Select(c => new CinemaDto
			{
				Id = c.Id,
				Name = c.Name,
                CinemaCenterId = c.CinemaCenterId,
                CinemaTypeId = c.CinemaTypeId,
                CinemaTypeName = c.CinemaType.Name,
				CinemaCenterName = c.CinemaCenter.Name,
				MaxSeatCapacity = c.MaxSeatCapacity,
				Column = c.Column,
				Row = c.Row,
				Description = c.Description,
				CreateTime = c.CreateTime,
				UpdateTime = c.UpdateTime
			}).ToListAsync();
            return query.AsQueryable();
		}

		public async Task<IQueryable<CinemaDto>> GetAllAsync(string? cinemaCenterName)
        {
            var query = _dbContext.Cinemas.Select(c => new CinemaDto
            {
                Id = c.Id,
                Name = c.Name,
				CinemaCenterId = c.CinemaCenterId,
				CinemaTypeId = c.CinemaTypeId,
				CinemaTypeName = c.CinemaType.Name,
                CinemaCenterName = c.CinemaCenter.Name,
                MaxSeatCapacity = c.MaxSeatCapacity,
                Column = c.Column,
                Row = c.Row,
                Description = c.Description,
                CreateTime = c.CreateTime,
                UpdateTime = c.UpdateTime
            }).AsNoTracking();
            if (!string.IsNullOrEmpty(cinemaCenterName))
            {
                query = query.Where(x => x.CinemaCenterName == cinemaCenterName);
                if (query == null)
                {
                    return null;
                }
            }
            return query.AsQueryable();
        }

        public async Task<ResponseObject<CinemaDto>> GetCinemaById(Guid id)
        {
            var result = await _dbContext.Cinemas.FindAsync(id);
            if (result == null)
            {
                return new ResponseObject<CinemaDto>
                {
                    Status = 404,
                    Message = "Not found",
                    Data = null
                };
            }

            var cinemaType = await _dbContext.CinemaTypes.FindAsync(result.CinemaTypeId);
            var cinemaCenter = await _dbContext.CinemaCenters.FindAsync(result.CinemaCenterId);

            return new ResponseObject<CinemaDto>
            {
                Status = 200,
                Message = "Success",
                Data = new CinemaDto
                {
                    Id = result.Id,
                    Name = result.Name,
                    CinemaTypeName = cinemaType?.Name ?? string.Empty,
					CinemaTypeId = result.CinemaTypeId,
					CinemaCenterName = cinemaCenter?.Name ?? string.Empty,
                    MaxSeatCapacity = result.MaxSeatCapacity,
                    Column = result.Column,
                    Row = result.Row,
                    Description = result.Description,
                    CreateTime = result.CreateTime,
                    UpdateTime = result.UpdateTime
                }
            };
        }
    }
}