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
			var scheduleFilm = await _db.Schedules
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
			// Check thời gian bắt đầu phải lớn hơn thời gian hiện tại ít nhất 30 phút
			if (showTime.StartTime.HasValue)
			{
				var currentTime = DateTime.Now;
				var timeDifference = showTime.StartTime.Value - currentTime;

				if (timeDifference.TotalMinutes <= 30)
				{
					return new ResponseObject<ShowTime>
					{
						Data = null,
						Message = "Thời gian bắt đầu phải lớn hơn thời gian hiện tại 30 phút.",
						Status = StatusCodes.Status400BadRequest
					};
				}
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
			if (showTime.ShowtimeEndDate.HasValue)
			{
				var startDate = showTime.ShowtimeDate.Value.Date;
				var endDate = showTime.ShowtimeEndDate.Value.Date;
				
				// Kiểm tra nếu ngày kết thúc trước ngày bắt đầu
				if (endDate < startDate)
				{
					return new ResponseObject<ShowTime>
					{
						Data = null,
						Message = "Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu.",
						Status = StatusCodes.Status400BadRequest
					};
				}
				// Kiểm tra nếu ngày kết thúc không được vượt quá ngày kết thúc của lịch chiếu
				if (scheduleFilm.EndDate < endDate)
				{
					return new ResponseObject<ShowTime>
					{
						Data = null,
						Message = "Ngày kết thúc không được vượt quá ngày kết thúc của lịch chiếu.",
						Status = StatusCodes.Status400BadRequest
					};
				}
				// Kiểm tra nếu khoảng cách giữa ngày kết thúc và ngày bắt đầu vượt quá 7 ngày
				var dateDifference = (endDate - startDate).TotalDays;
				if (dateDifference > 7)
				{
					return new ResponseObject<ShowTime>
					{
						Data = null,
						Message = "Khoảng cách giữa ngày bắt đầu và ngày kết thúc không được vượt quá 7 ngày.",
						Status = StatusCodes.Status400BadRequest
					};
				}
				// Lặp qua từng ngày trong khoảng từ startDate đến endDate
				var showTimesToCreate = new List<ShowTime>();

				for (var currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
				{
					//Tạo thời gian bắt đầu và kết thúc mới 
					var adjustedStartTime = new DateTime(
						currentDate.Year,
						currentDate.Month,
						currentDate.Day,
						showTime.StartTime.Value.Hour,
						showTime.StartTime.Value.Minute,
						0
						);
					var adjustedEndTime = new DateTime(
						currentDate.Year,
						currentDate.Month,
						currentDate.Day,
						showTime.EndTime.Value.Hour,
						showTime.EndTime.Value.Minute,
						0
						);
					// Kiểm tra suất chiếu trùng lặp trong ngày
					var overlappingShowTimeForDay = await _db.ShowTimes
						.Where(st => st.CinemaId == showTime.CinemaId
									 && st.ShowtimeDate.Value == currentDate
									 && ((showTime.StartTime >= st.StartTime && showTime.StartTime <= st.EndTime)
										 || (showTime.EndTime >= st.StartTime && showTime.EndTime <= st.EndTime)))
						.FirstOrDefaultAsync();

					if (overlappingShowTimeForDay != null)
					{
						return new ResponseObject<ShowTime>
						{
							Data = null,
							Message = $"Giờ chiếu phim trùng với giờ chiếu phim hiện tại vào ngày {currentDate:yyyy-MM-dd}.",
							Status = StatusCodes.Status400BadRequest
						};
					}

					// Tìm suất chiếu gần nhất trước thời gian bắt đầu trong ngày hiện tại
					var previousTimeShowTime2 = await _db.ShowTimes
						.Where(st => st.CinemaId == showTime.CinemaId && st.ShowtimeDate.Value == currentDate)
						.Where(st => st.EndTime < showTime.StartTime)
						.OrderByDescending(st => st.EndTime)
						.FirstOrDefaultAsync();

					// Tìm suất chiếu gần nhất sau thời gian kết thúc trong ngày hiện tại
					var nextShowTime2 = await _db.ShowTimes
						.Where(st => st.CinemaId == showTime.CinemaId && st.ShowtimeDate.Value == currentDate)
						.Where(st => st.StartTime > showTime.EndTime)
						.OrderBy(st => st.StartTime)
						.FirstOrDefaultAsync();

					// Kiểm tra điều kiện thời gian bắt đầu
					var startTimeSpan = showTime.StartTime.Value.TimeOfDay;
					if (startTimeSpan < eightAM || startTimeSpan > eightPM)
					{
						return new ResponseObject<ShowTime>
						{
							Data = null,
							Message = $"Giờ bắt đầu phải nằm trong khoảng 8h sáng đến 23h vào ngày {currentDate:yyyy-MM-dd}.",
							Status = StatusCodes.Status400BadRequest
						};
					}

					// Kiểm tra thời gian cách suất chiếu trước đó
					if (previousTimeShowTime2 != null)
					{
						var checkStartTime = showTime.StartTime.Value - previousTimeShowTime2.EndTime.Value;
						if (checkStartTime.TotalMinutes < 30)
						{
							return new ResponseObject<ShowTime>
							{
								Data = null,
								Message = $"Giờ chiếu vào ngày {currentDate:yyyy-MM-dd} phải cách suất chiếu trước ít nhất 30 phút.",
								Status = StatusCodes.Status400BadRequest
							};
						}
					}

					// Kiểm tra thời gian cách suất chiếu tiếp theo
					if (nextShowTime2 != null)
					{
						var checkEndTime = nextShowTime.StartTime.Value - showTime.EndTime.Value;
						if (checkEndTime.TotalMinutes < 30)
						{
							return new ResponseObject<ShowTime>
							{
								Data = null,
								Message = $"Giờ chiếu vào ngày {currentDate:yyyy-MM-dd} phải cách suất chiếu tiếp theo ít nhất 30 phút.",
								Status = StatusCodes.Status400BadRequest
							};
						}
					}

					// Tạo suất chiếu cho ngày hiện tại
					var newShowTime = new ShowTime
					{
						Id = Guid.NewGuid(),
						ScheduleId = showTime.ScheduleId.Value,
						CinemaId = showTime.CinemaId.Value,
						ScreenTypeId = showTime.ScreenTypeId.Value,
						TranslationTypeId = showTime.TranslationTypeId.Value,
						StartTime = adjustedStartTime,
						EndTime = adjustedEndTime,
						ShowtimeDate = currentDate,
						Desciption = showTime.Desciption,
						Status = ShowtimeStatus.ComingSoon
					};

					showTimesToCreate.Add(newShowTime);
				}


				// Thêm tất cả các suất chiếu vào database
				await _db.ShowTimes.AddRangeAsync(showTimesToCreate);
				await _db.SaveChangesAsync();

				return new ResponseObject<ShowTime>
				{
					Data = null,
					Message = "Tạo thành công các suất chiếu từ ngày bắt đầu đến ngày kết thúc.",
					Status = StatusCodes.Status200OK
				};
			}
			else
			{
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
					Status = ShowtimeStatus.ComingSoon
				};

				_db.ShowTimes.Add(newShowTime);
				await _db.SaveChangesAsync();

				return new ResponseObject<ShowTime>
				{
					Data = newShowTime,
					Message = "Tạo thành công suất chiếu",
					Status = StatusCodes.Status200OK
				};
			}
		}

		public async Task<ResponseObject<ShowTime>> Delete(Guid id)
		{
			var showTime = await _db.ShowTimes.FindAsync(id);
			var checkShowTime = await _db.Tickets.AnyAsync(x => x.ShowTimeId == id);
			if (showTime == null)
			{
				return new ResponseObject<ShowTime>
				{
					Data = null,
					Message = "Không tìm thấy suất chiếu",
					Status = StatusCodes.Status404NotFound
				};
			}
			if (showTime.Status == ShowtimeStatus.Ended || showTime.Status == ShowtimeStatus.Showing)
			{
				return new ResponseObject<ShowTime>
				{
					Data = null,
					Message = "Không thể xóa suất chiếu đã kết thúc hoặc đang chiếu.",
					Status = StatusCodes.Status400BadRequest
				};
			}
			if (checkShowTime)
			{
				return new ResponseObject<ShowTime>
				{
					Data = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Không thể xóa suất chiếu vì nó được tham chiếu",
				};
			}
            _db.ShowTimes.Remove(showTime);
			await _db.SaveChangesAsync();
			return new ResponseObject<ShowTime>
			{
				Data = showTime,
				Message = "Xóa thành công",
				Status = StatusCodes.Status200OK
			};
		}

        public async Task<ResponseObject<ShowTime>> Update(ShowTimeUpdateRequest showTime)
        {
            // Lấy suất chiếu cần cập nhật
            var existingShowTime = await _db.ShowTimes.FindAsync(showTime.Id);
            if (existingShowTime == null)
            {
                return new ResponseObject<ShowTime>
                {
                    Data = null,
                    Message = "không tìm thấy",
                    Status = StatusCodes.Status404NotFound
                };
            }
			if (existingShowTime.Status == ShowtimeStatus.Ended)
			{
				return new ResponseObject<ShowTime>
				{
					Data = null,
					Message = "Không được update suất chiếu đã kết thúc.",
					Status = StatusCodes.Status400BadRequest
				};
			}
            // Check null các trường bắt buộc
            if (!showTime.FilmId.HasValue || !showTime.ScheduleId.HasValue || !showTime.CinemaId.HasValue ||
                !showTime.ScreenTypeId.HasValue || !showTime.TranslationTypeId.HasValue ||
                !showTime.StartTime.HasValue || !showTime.EndTime.HasValue)
            {
                return new ResponseObject<ShowTime>
                {
                    Data = null,
                    Message = "Thiếu dữ liệu",
                    Status = StatusCodes.Status400BadRequest
                };
            }
			// Check thời gian bắt đầu phải lớn hơn thời gian hiện tại ít nhất 30 phút
			if (showTime.StartTime.HasValue)
			{
				var currentTime = DateTime.Now;
				var timeDifference = showTime.StartTime.Value - currentTime;
				var timeDifference2 = existingShowTime.StartTime.Value - currentTime;
				if (timeDifference2.TotalMinutes <= 30)
				{
					return new ResponseObject<ShowTime>
					{
						Data = null,
						Message = "Không được update suất chiếu khi cách thời gian chiếu lớn hơn 30 phút.",
						Status = StatusCodes.Status400BadRequest
					};
				}

				if (timeDifference.TotalMinutes <= 30)
				{
					return new ResponseObject<ShowTime>
					{
						Data = null,
						Message = "Thời gian bắt đầu phải lớn hơn thời gian hiện tại 30 phút.",
						Status = StatusCodes.Status400BadRequest
					};
				}
			}

			var eightAM = new TimeSpan(8, 0, 0);
            var eightPM = new TimeSpan(23, 0, 0);

            // Tìm suất chiếu gần nhất trước thời gian bắt đầu của suất chiếu đang cập nhật
            var previousTimeShowTime = await _db.ShowTimes
                .Where(st => st.CinemaId == showTime.CinemaId && st.ShowtimeDate == showTime.ShowtimeDate && st.Id != showTime.Id)
                .Where(st => st.EndTime < showTime.StartTime)
                .OrderByDescending(st => st.EndTime)
                .FirstOrDefaultAsync();

            // Tìm suất chiếu có thời gian bắt đầu gần nhất sau thời gian kết thúc của suất chiếu đang cập nhật
            var nextShowTime = await _db.ShowTimes
                .Where(st => st.CinemaId == showTime.CinemaId && st.ShowtimeDate == showTime.ShowtimeDate && st.Id != showTime.Id)
                .Where(st => st.StartTime > showTime.EndTime)
                .OrderBy(st => st.StartTime)
                .FirstOrDefaultAsync();

            // Tìm suất chiếu có thời gian trùng nhau trong cùng một ngày
            var overlappingShowTime = await _db.ShowTimes
                .Where(st => st.CinemaId == showTime.CinemaId && st.ShowtimeDate == showTime.ShowtimeDate && st.Id != showTime.Id)
                .Where(st => (showTime.StartTime >= st.StartTime && showTime.StartTime <= st.EndTime)
                             || (showTime.EndTime >= st.StartTime && showTime.EndTime <= st.EndTime))
                .FirstOrDefaultAsync();

            // Kiểm tra trùng giờ suất chiếu
            if (overlappingShowTime != null)
            {
                return new ResponseObject<ShowTime>
                {
                    Data = null,
                    Message = "Giờ chiếu phim trùng với giờ chiếu phim hiện tại.",
                    Status = StatusCodes.Status400BadRequest
                };
            }

            // Kiểm tra giờ bắt đầu
            if (showTime.StartTime.Value.TimeOfDay < eightAM)
            {
                return new ResponseObject<ShowTime>
                {
                    Data = null,
                    Message = "Giờ bắt đầu phải lớn hơn hoặc bằng 8 giờ sáng.",
                    Status = StatusCodes.Status400BadRequest
                };
            }

            if (showTime.StartTime.Value.TimeOfDay > eightPM)
            {
                return new ResponseObject<ShowTime>
                {
                    Data = null,
                    Message = "Giờ bắt đầu phải nhỏ hơn hoặc bằng 23 giờ.",
                    Status = StatusCodes.Status400BadRequest
                };
            }

            // Kiểm tra khoảng cách thời gian với suất chiếu trước đó
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

            // Kiểm tra khoảng cách thời gian với suất chiếu tiếp theo
            if (nextShowTime != null)
            {
                var checkEndTime = nextShowTime.StartTime.Value - showTime.EndTime.Value;
                if (checkEndTime.TotalMinutes < 30)
                {
                    return new ResponseObject<ShowTime>
                    {
                        Data = null,
                        Message = "Giờ chiếu phải cách giờ chiếu tiếp theo 30 phút.",
                        Status = StatusCodes.Status400BadRequest
                    };
                }
            }

            // Cập nhật thông tin suất chiếu
            existingShowTime.ScheduleId = showTime.ScheduleId.Value;
            existingShowTime.CinemaId = showTime.CinemaId.Value;
            existingShowTime.ScreenTypeId = showTime.ScreenTypeId.Value;
            existingShowTime.TranslationTypeId = showTime.TranslationTypeId.Value;
            existingShowTime.StartTime = showTime.StartTime.Value;
            existingShowTime.EndTime = showTime.EndTime.Value;
			existingShowTime.Status = showTime.Status;
			_db.ShowTimes.Update(existingShowTime);
            await _db.SaveChangesAsync();

            return new ResponseObject<ShowTime>
            {
                Data = existingShowTime,
                Message = "Update thành công",
                Status = StatusCodes.Status200OK
            };
        }

		public async Task<ResponseObject<ShowTime>> UpdateStatus(ShowTimeUpdateStatus updateStatus)
		{
			var existingShowTime = await _db.ShowTimes.FindAsync(updateStatus.Id);
			if (existingShowTime == null)
			{
				return new ResponseObject<ShowTime>
				{
					Data = null,
					Message = "Không tìm thấy suất chiếu",
					Status = StatusCodes.Status404NotFound
				};
			}
			existingShowTime.Status = updateStatus.Status;
			_db.ShowTimes.Update(existingShowTime);
			await _db.SaveChangesAsync();
			return new ResponseObject<ShowTime>
			{
				Data = existingShowTime,
				Message = "Cập nhật trạng thái thành công",
				Status = StatusCodes.Status200OK
			};
		}
	}
}