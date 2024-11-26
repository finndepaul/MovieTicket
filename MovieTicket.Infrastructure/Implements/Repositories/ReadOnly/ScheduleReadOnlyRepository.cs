using AutoMapper;
using Bogus;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class ScheduleReadOnlyRepository : IScheduleReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _dbContext;
        private readonly IMapper _mapper;

        public ScheduleReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<PageList<ScheduleDto>> GetAllPagingAsync(string? filmName, DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters, CancellationToken cancellationToken)
        {
            startDate ??= DateTime.Now;
            endDate ??= DateTime.Now;
            var scheduleDtos = from schedule in _dbContext.Schedules
                               join film in _dbContext.Films on schedule.FilmId equals film.Id
                               where (string.IsNullOrEmpty(filmName) || film.Name.Contains(filmName)) &&
                                      schedule.StartDate >= startDate &&
                                      schedule.EndDate <= endDate
                               select new ScheduleDto
                               {
                                   Id = schedule.Id,
                                   FilmId = schedule.FilmId,
                                   StartDate = schedule.StartDate,
                                   EndDate = schedule.EndDate,
                                   Type = schedule.Type,
                                   Status = schedule.Status,
                                   FilmName = film.Name
                               };
            int count = await scheduleDtos.CountAsync(cancellationToken);
            var data = await scheduleDtos.Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            return new PageList<ScheduleDto>(data, count, pagingParameters.PageNumber, pagingParameters.PageSize);
        }

        public async Task<IQueryable<ScheduleDto>> GetAllAsync()
        {
            // Truy vấn để lấy dữ liệu từ bảng Schedules và Films, sau đó ánh xạ vào ScheduleDto
            var scheduleDtos = from schedule in _dbContext.Schedules
                               join film in _dbContext.Films on schedule.FilmId equals film.Id
                               select new ScheduleDto
                               {
                                   Id = schedule.Id,
                                   FilmId = schedule.FilmId,
                                   StartDate = schedule.StartDate,
                                   EndDate = schedule.EndDate,
                                   Type = schedule.Type,
                                   Status = schedule.Status,
                                   FilmName = film.Name // Lấy tên phim
                               };

            // Kiểm tra nếu không có lịch chiếu nào thì ném ra ngoại lệ
            if (!scheduleDtos.Any())
            {
                throw new InvalidOperationException("No schedules found.");
            }

            // Trả về danh sách lịch chiếu
            return scheduleDtos;
        }

        // Phương thức lấy lịch chiếu theo FilmId
        public async Task<IQueryable<ScheduleDto>> GetByFilmIdAsync(Guid filmId)
        {
            // Kiểm tra nếu FilmId rỗng thì ném ra ngoại lệ
            if (filmId == Guid.Empty)
            {
                throw new ArgumentException("Invalid Film ID.", nameof(filmId));
            }

            // Truy vấn để lấy dữ liệu từ bảng Schedules và Films theo FilmId, sau đó ánh xạ vào ScheduleDto
            var scheduleDtos = from schedule in _dbContext.Schedules
                               join film in _dbContext.Films on schedule.FilmId equals film.Id
                               where schedule.FilmId == filmId
                               select new ScheduleDto
                               {
                                   Id = schedule.Id,
                                   FilmId = schedule.FilmId,
                                   StartDate = schedule.StartDate,
                                   EndDate = schedule.EndDate,
                                   Type = schedule.Type,
                                   Status = schedule.Status,
                                   FilmName = film.Name, // Lấy tên phim
                                   FilmReleaseDate = film.StartDate // Lấy ngày ra mắt phim
                               };

            // Kiểm tra nếu không có lịch chiếu nào cho FilmId thì ném ra ngoại lệ
            if (!scheduleDtos.Any())
            {
                throw new InvalidOperationException($"No schedules found for Film ID {filmId}.");
            }

            // Trả về danh sách lịch chiếu
            return scheduleDtos;
        }

        // Phương thức lấy lịch chiếu theo Id
        public async Task<ScheduleDto> GetByIdAsync(Guid id)
        {
            // Kiểm tra nếu Id rỗng thì ném ra ngoại lệ
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid ID.", nameof(id));
            }

            // Truy vấn để lấy dữ liệu từ bảng Schedules và Films theo Id, sau đó ánh xạ vào ScheduleDto
            var scheduleDto = await (from schedule in _dbContext.Schedules
                                     join film in _dbContext.Films on schedule.FilmId equals film.Id
                                     where schedule.Id == id
                                     select new ScheduleDto
                                     {
                                         Id = schedule.Id,
                                         FilmId = schedule.FilmId,
                                         StartDate = schedule.StartDate,
                                         EndDate = schedule.EndDate,
                                         Type = schedule.Type,
                                         Status = schedule.Status,
                                         FilmName = film.Name, // Lấy tên phim
                                         FilmReleaseDate = film.StartDate // Lấy ngày ra mắt phim
                                     }).FirstOrDefaultAsync();

            // Kiểm tra nếu không có lịch chiếu nào cho Id thì ném ra ngoại lệ
            if (scheduleDto == null)
            {
                throw new InvalidOperationException($"No schedule found for ID {id}.");
            }

            // Trả về lịch chiếu
            return scheduleDto;
        }

        public async Task<IQueryable<FilmForCreateDto>> GetFilmForCreateAsync()
        {
            var filmsWithoutSchedule = await _dbContext.Films
                .Where(film => !_dbContext.Schedules.Any(schedule => schedule.FilmId == film.Id))
                .Select(film => new FilmForCreateDto
                {
                    Id = film.Id,
                    Name = film.Name,
                    StartDate = film.StartDate
                })
                .ToListAsync();

            return filmsWithoutSchedule.AsQueryable();
        }
    }
}