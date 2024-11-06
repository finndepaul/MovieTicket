using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
	public class ShowTimeReadWriteRepository : IShowTimeReadWriteRepository
	{
		private readonly MovieTicketReadWriteDbContext _db;
		private readonly IMapper _mapper;

		public ShowTimeReadWriteRepository(MovieTicketReadWriteDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		public async Task<ResponseObject<ShowTime>> Create(ShowTimeCreateRequest showTime)
		{
			// Tìm suất chiếu gần nhất trước thời gian bắt đầu của suất chiếu mới
			var previousTimeShowTime = await _db.ShowTimes
				.Where(st => st.CinemaId == showTime.CinemaId && st.ShowtimeDate.Value == showTime.ShowtimeDate.Value)
				.Where(st => st.EndTime < showTime.StartTime) 
				.OrderByDescending(st => st.EndTime)
				.FirstOrDefaultAsync();

			var eightAM = new TimeSpan(8, 0, 0);
			var eightPM = new TimeSpan(23, 0, 0);
			// Tìm suất chiếu có thời gian bắt đầu gần nhất sau thời gian kết thúc của suất chiếu mới
			var nextShowTime = await _db.ShowTimes
				.Where(st => st.CinemaId == showTime.CinemaId && st.ShowtimeDate.Value == showTime.ShowtimeDate.Value)
				.Where(st => st.StartTime > showTime.EndTime) 
				.OrderBy(st => st.StartTime) 
				.FirstOrDefaultAsync();


			// Tìm thời gian bắt đầu và kết thúc của lịch chiếu phim
			var schedule = await _db.Schedules
				.Where(x => x.FilmId == showTime.FilmId && (x.Status == ScheduleStatus.ComingSoon || x.Status == ScheduleStatus.Showing))
				.FirstOrDefaultAsync();

			// Check null các trường bắt buộc
			if (!showTime.FilmId.HasValue || !showTime.ScheduleId.HasValue ||
				!showTime.CinemaCenterId.HasValue || !showTime.CinemaId.HasValue ||
				!showTime.ScreenTypeId.HasValue || !showTime.TranslationTypeId.HasValue ||
				!showTime.StartTime.HasValue || !showTime.EndTime.HasValue ||
				string.IsNullOrEmpty(showTime.Desciption))
			{
				return new ResponseObject<ShowTime>
				{
					Data = null,
					Message = "Thiếu dữ liệu",
					Status = StatusCodes.Status400BadRequest
				};
			}

			// Tìm suất chiếu có thời gian trùng nhau trong cùng một ngày
			var overlappingShowTime = await _db.ShowTimes
				.Where(st => st.CinemaId == showTime.CinemaId
							 && st.ShowtimeDate.Value == showTime.ShowtimeDate.Value							 
							 && ((showTime.StartTime >= st.StartTime && showTime.StartTime <= st.EndTime)
								 || (showTime.EndTime >= st.StartTime && showTime.EndTime <= st.EndTime)))
				.FirstOrDefaultAsync();

			// Check thời gian suất chiếu không chồng chéo với suất chiếu khác trong cùng ngày
			if (overlappingShowTime != null)
			{
				return new ResponseObject<ShowTime>
				{
					Data = null,
					Message = "Giờ chiếu phim trùng với giờ chiếu phim hiện tại.",
					Status = StatusCodes.Status400BadRequest
				};
			}
			// check phải từ 8h sáng
			if (showTime.StartTime.HasValue)
			{
				var startTimeSpan = showTime.StartTime.Value.TimeOfDay;

				if (startTimeSpan < eightAM)
				{
					return new ResponseObject<ShowTime>
					{
						Data = null,
						Message = "Giờ bắt đầu phải lớn hơn hoặc bằng 8 giờ sáng.",
						Status = StatusCodes.Status400BadRequest
					};
				}
			}

			if (showTime.StartTime.HasValue)
			{
				var startTimeSpan = showTime.StartTime.Value.TimeOfDay;

				if (startTimeSpan > eightPM)
				{
					return new ResponseObject<ShowTime>
					{
						Data = null,
						Message = "Giờ bắt đầu phải nhỏ hơn hoặc bằng 23 giờ.",
						Status = StatusCodes.Status400BadRequest
					};
				}
			}

			// Check thời gian cho suất chiếu tiếp theo (phải cách ít nhất 30 phút với suất chiếu trước đó)
			if (previousTimeShowTime != null)
			{
				var checkStartTime = showTime.StartTime.Value - previousTimeShowTime.EndTime.Value;
				if (checkStartTime.TotalMinutes < 30)
				{
					return new ResponseObject<ShowTime>
					{
						Data = null,
						Message = "Giờ chiếu phải cách giờ chiếu trước ít nhất 30 phút.",
						Status = StatusCodes.Status400BadRequest
					};
				}
			}
			if (nextShowTime != null)
			{
				var checkEndTime = nextShowTime.StartTime.Value - showTime.EndTime.Value;
				if (checkEndTime.TotalMinutes < 30)
				{
					return new ResponseObject<ShowTime>
					{
						Data = null,
						Message = "Giờ chiếu phải cách giờ chiếu tiếp theo 30p.",
						Status = StatusCodes.Status400BadRequest
					};
				}
			}
			if (previousTimeShowTime != null && nextShowTime != null)
			{
				var checkEndTime = nextShowTime.StartTime.Value - showTime.EndTime.Value;
				var checkStartTime = showTime.StartTime.Value - previousTimeShowTime.EndTime.Value;
				if (checkStartTime.TotalMinutes < 30 && checkEndTime.TotalMinutes < 30)
				{
					return new ResponseObject<ShowTime>
					{
						Data = null,
						Message = "Giờ chiếu phải cách giờ chiếu trước và giờ chiếu tiếp theo 30p.",
						Status = StatusCodes.Status400BadRequest
					};
				}
			}

			// Tạo suất chiếu mới
			var newShowTime = new ShowTime
			{
				Id = Guid.NewGuid(),
				ScheduleId = showTime.ScheduleId.Value,
				CinemaId = showTime.CinemaId.Value,
				ScreenTypeId = showTime.ScreenTypeId.Value,
				TranslationTypeId = showTime.TranslationTypeId.Value,
				StartTime = showTime.StartTime.Value,
				EndTime = showTime.EndTime.Value,
				ShowtimeDate = showTime.ShowtimeDate ?? DateTime.Today,
				Desciption = showTime.Desciption,
				Status = showTime.Status
			};

			_db.ShowTimes.Add(newShowTime);
			await _db.SaveChangesAsync();

			return new ResponseObject<ShowTime>
			{
				Data = newShowTime,
				Message = "Showtime created successfully.",
				Status = StatusCodes.Status200OK
			};
		}

		public async Task<ResponseObject<ShowTime>> Delete(Guid id)
		{
			var showTime = await _db.ShowTimes.FindAsync(id);
			if (showTime == null)
			{
				return new ResponseObject<ShowTime>
				{
					Data = null,
					Message = "ShowTime not found",
					Status = StatusCodes.Status404NotFound
				};
			}
			_db.ShowTimes.Remove(showTime);
			await _db.SaveChangesAsync();
			return new ResponseObject<ShowTime>
			{
				Data = showTime,
				Message = "Delete success",
				Status = StatusCodes.Status200OK
			};
		}

	}
}