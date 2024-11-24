using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class ShowTimeReadOnlyRepository : IShowTimeReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _db;
        private readonly IMapper _mapper;

        public ShowTimeReadOnlyRepository(MovieTicketReadOnlyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

		public async Task<PageList<ShowTimeDto>> GetAll(ShowTimeSearch? showTimeSearch, PagingParameters pagingParameters)
		{
			var showTimes = (from showTime in _db.ShowTimes
							 join cinema in _db.Cinemas on showTime.CinemaId equals cinema.Id
							 join cinemaCenter in _db.CinemaCenters on cinema.CinemaCenterId equals cinemaCenter.Id
							 join schedule in _db.Schedules on showTime.ScheduleId equals schedule.Id
							 join film in _db.Films on schedule.FilmId equals film.Id
							 join screenType in _db.ScreenTypes on showTime.ScreenTypeId equals screenType.Id
							 join translationType in _db.TranslationTypes on showTime.TranslationTypeId equals translationType.Id
							 select new ShowTimeDto
							 {
								 Id = showTime.Id,
								 CinemaId = showTime.Cinema.Id,
								 CinemaCenterId = cinemaCenter.Id,
								 CinemaName = cinema.Name,
								 CinemaCenterName = cinemaCenter.Name,
								 FilmName = film.Name,
								 FilmId = film.Id,
								 StartDate = schedule.StartDate,
								 EndDate = schedule.EndDate,
								 ScreenTypeName = screenType.Type,
								 ScheduleId = showTime.Schedule.Id,
								 ScreenTypeId = showTime.ScreenType.Id,
								 TranslationTypeName = translationType.Type,
								 TranslationTypeId = showTime.TranslationType.Id,
								 StartTime = showTime.StartTime,
								 EndTime = showTime.EndTime,
								 ShowtimeDate = showTime.ShowtimeDate,
								 Desciption = showTime.Desciption,
								 Status = showTime.Status
							 }).AsQueryable();

			if (showTimeSearch.CinemaCenterId.HasValue)
			{
				showTimes = showTimes.Where(x => x.CinemaCenterId == showTimeSearch.CinemaCenterId);
			}
			if (showTimeSearch.CinemaId.HasValue)
			{
				showTimes = showTimes.Where(x => x.CinemaId == showTimeSearch.CinemaId);
			}
			if (showTimeSearch.ShowtimeDate.HasValue)
			{
				showTimes = showTimes.Where(x => x.ShowtimeDate == showTimeSearch.ShowtimeDate);
			}
			showTimes = showTimes.OrderBy(x => x.StartTime < DateTime.Now).ThenBy(x => x.StartTime);
			int count = await showTimes.CountAsync();
			var data = await showTimes.Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
					.Take(pagingParameters.PageSize)
					.ToListAsync();

			return new PageList<ShowTimeDto>(data, count, pagingParameters.PageNumber, pagingParameters.PageSize);
		}

		public async Task<ResponseObject<ShowTimeDto>> GetById(Guid id)
        {
            var showTimes = await (from showTime in _db.ShowTimes
                                   join cinema in _db.Cinemas on showTime.CinemaId equals cinema.Id
								   join cinemaCenter in _db.CinemaCenters on cinema.CinemaCenterId equals cinemaCenter.Id
								   join schedule in _db.Schedules on showTime.ScheduleId equals schedule.Id
								   join film in _db.Films on schedule.FilmId equals film.Id
								   join screenType in _db.ScreenTypes on showTime.ScreenTypeId equals screenType.Id
                                   join translationType in _db.TranslationTypes on showTime.TranslationTypeId equals translationType.Id
                                   where showTime.Id == id
                                   select new ShowTimeDto
                                   {
									   Id = showTime.Id,
									   CinemaId = showTime.Cinema.Id,
									   CinemaCenterId = cinemaCenter.Id,
									   CinemaName = cinema.Name,
									   CinemaCenterName = cinemaCenter.Name,
									   FilmName = film.Name,
									   FilmId = film.Id,
									   StartDate = schedule.StartDate,
									   EndDate = schedule.EndDate,
									   ScreenTypeName = screenType.Type,
									   ScheduleId = showTime.Schedule.Id,
									   ScreenTypeId = showTime.ScreenType.Id,
									   TranslationTypeName = translationType.Type,
									   TranslationTypeId = showTime.TranslationType.Id,
									   StartTime = showTime.StartTime,
									   EndTime = showTime.EndTime,
									   ShowtimeDate = showTime.ShowtimeDate,
									   Desciption = showTime.Desciption,
									   Status = showTime.Status
									   
								   }).FirstOrDefaultAsync();
            if (showTimes == null)
            {
                return new ResponseObject<ShowTimeDto>
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Không tìm thấy rạp",
                    Data = null
                };
            }
            return new ResponseObject<ShowTimeDto>
            {
                Data = showTimes,
                Status = StatusCodes.Status200OK,
                Message = "Tìm rạp thành công"
            };
        }
    }
}