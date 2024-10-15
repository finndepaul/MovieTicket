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
			// Tìm thời gian kết thúc của suất chiếu cuối cùng trong ngày tại cùng rạp và loại màn hình
			var lastShowTime = await _db.ShowTimes
				.Where(st => st.CinemaId == showTime.CinemaId && st.ScreenTypeId == showTime.ScreenTypeId && st.ShowtimeDate.Value == showTime.ShowtimeDate.Value)
				.OrderByDescending(st => st.EndTime)
				.FirstOrDefaultAsync();

			// Tìm thời gian bắt đầu và kết thúc của lịch chiếu phim
			var schedule = await _db.Schedules
				.Where(x => x.FilmId == showTime.FilmId && (x.Status == ScheduleStatus.ComingSoon || x.Status == ScheduleStatus.Showing))
				.FirstOrDefaultAsync();

			// Tìm suất chiếu có thời gian trùng nhau trong cùng một ngày
			var overlappingShowTime = await _db.ShowTimes
				.Where(st => st.CinemaId == showTime.CinemaId && st.ScreenTypeId == showTime.ScreenTypeId && st.ShowtimeDate.Value == showTime.ShowtimeDate.Value
							 && ((showTime.StartTime >= st.StartTime && showTime.StartTime <= st.EndTime)
								  || (showTime.EndTime >= st.StartTime && showTime.EndTime <= st.EndTime)))
				.FirstOrDefaultAsync();

			// Check null các trường bắt buộc
			if (!showTime.FilmId.HasValue || !showTime.ScheduleId.HasValue ||
				!showTime.CinemaCenterId.HasValue || !showTime.CinemaId.HasValue ||
				!showTime.ScreenTypeId.HasValue || !showTime.TranslationTypeId.HasValue ||
				!showTime.StartTime.HasValue || !showTime.EndTime.HasValue ||
				string.IsNullOrEmpty(showTime.Desciption) || !showTime.Status.HasValue)
			{
				return new ResponseObject<ShowTime>
				{
					Data = null,
					Message = "Thiếu dữ liệu",
					Status = StatusCodes.Status400BadRequest
				};
			}

			// Check thời gian bắt đầu và kết thúc của suất chiếu
			if (showTime.EndTime <= showTime.StartTime)
			{
				return new ResponseObject<ShowTime>
				{
					Data = null,
					Message = "Lỗi thời gian bắt đầu và kết thúc",
					Status = StatusCodes.Status400BadRequest
				};
			}

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

			// Check thời gian cho suất chiếu tiếp theo (phải cách ít nhất 30 phút với suất chiếu trước đó)
			if (lastShowTime != null)
			{
				var timeDifference = showTime.StartTime.Value - lastShowTime.EndTime.Value;
				if (timeDifference.TotalMinutes < 30)
				{
					return new ResponseObject<ShowTime>
					{
						Data = null,
						Message = "Giờ chiếu phải cách giờ chiếu trước ít nhất 30 phút.",
						Status = StatusCodes.Status400BadRequest
					};
				}
			}

			// Check thời gian của suất chiếu phải nằm trong khoảng thời gian của lịch chiếu
			if (schedule != null && (showTime.StartTime.Value < schedule.StartDate || showTime.EndTime.Value > schedule.EndDate))
			{
				return new ResponseObject<ShowTime>
				{
					Data = null,
					Message = "Giờ chiếu phải nằm trong khung thời gian đã định",
					Status = StatusCodes.Status400BadRequest
				};
			}

			// Tạo suất chiếu mới
			var newShowTime = new ShowTime
			{
				Id = Guid.NewGuid(),
				FilmId = showTime.FilmId.Value,
				ScheduleId = showTime.ScheduleId.Value,
				CinemaCenterId = showTime.CinemaCenterId.Value,
				CinemaId = showTime.CinemaId.Value,
				ScreenTypeId = showTime.ScreenTypeId.Value,
				TranslationTypeId = showTime.TranslationTypeId.Value,
				StartTime = showTime.StartTime.Value,
				EndTime = showTime.EndTime.Value,
				ShowtimeDate = showTime.ShowtimeDate ?? DateTime.Today,
				Desciption = showTime.Desciption,
				Status = showTime.Status.Value
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