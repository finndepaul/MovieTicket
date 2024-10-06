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
            // Tìm thời gian kết thúc của suất chiếu cuối cùng
            var lastShowTime = await _db.ShowTimes
                       .Where(st => st.CinemaId == showTime.CinemaId && st.ScreenTypeId == showTime.ScreenTypeId && st.ShowtimeDate.Value == DateTime.Today)
                       .OrderByDescending(st => st.EndTime)
                       .FirstOrDefaultAsync();
            // Tìm thời gian bắt đầu và kết thúc của lịch chiếu phim
            var dateTime = await _db.Schedules
                        .Where(x => x.FilmId == showTime.FilmId && x.Status.Value == ScheduleStatus.ComingSoon || x.Status.Value == ScheduleStatus.Showing)
                        .FirstOrDefaultAsync();
            // Tìm suất chiếu có thời gian bắt đầu và kết thúc trùng nhau
            var showTimeExist = await _db.ShowTimes
                       .Where(st => st.CinemaId == showTime.CinemaId && st.ScreenTypeId == showTime.ScreenTypeId && st.ShowtimeDate.Value == DateTime.Today)
                       .FirstOrDefaultAsync();
            //Check null
            if (!showTime.FilmId.HasValue || !showTime.ScheduleId.HasValue ||
                !showTime.CinemaCenterId.HasValue || !showTime.CinemaId.HasValue ||
                !showTime.ScreenTypeId.HasValue || !showTime.TranslationTypeId.HasValue ||
                !showTime.StartTime.HasValue || !showTime.EndTime.HasValue ||
                string.IsNullOrEmpty(showTime.Desciption) || !showTime.Status.HasValue)
            {
                return new ResponseObject<ShowTime>
                {
                    Data = null,
                    Message = "All fields are required.",
                    Status = StatusCodes.Status400BadRequest
                };
            }

            // Check thời gian bắt đầu và kết thúc
            if (showTime.EndTime <= showTime.StartTime)
            {
                return new ResponseObject<ShowTime>
                {
                    Data = null,
                    Message = "End time must be greater than start time.",
                    Status = StatusCodes.Status400BadRequest
                };
            }

            // Check thời gian cho suất chiếu tiếp theo
            if (lastShowTime != null || lastShowTime.StartTime.HasValue)
            {
                var time = showTime.StartTime.Value - lastShowTime.EndTime.Value;
                if (time.TotalMinutes < 30)
                {
                    return new ResponseObject<ShowTime>
                    {
                        Data = null,
                        Message = "Invalid time",
                        Status = StatusCodes.Status400BadRequest
                    };
                }
            }
            // Check chùng 1 khoảng thời gian trong 1 ngày
            if (showTimeExist.StartTime.Value <= showTime.StartTime.Value && showTime.StartTime.Value <= showTimeExist.EndTime.Value)
            {
                return new ResponseObject<ShowTime>
                {
                    Data = null,
                    Message = "Invalid time",
                    Status = StatusCodes.Status400BadRequest
                };
            }
            // Check chùng 1 khoảng thời gian trong 1 ngày
            if (showTime.StartTime.Value <= showTimeExist.StartTime.Value)
            {
                return new ResponseObject<ShowTime>
                {
                    Data = null,
                    Message = "Invalid time",
                    Status = StatusCodes.Status400BadRequest
                };
            } // thêm mới
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
                ShowtimeDate = DateTime.Today,
                Desciption = showTime.Desciption,
                Status = showTime.Status.Value
            };

            // Assuming _context is your DbContext
            _db.ShowTimes.Add(newShowTime);
            await _db.SaveChangesAsync();

            return new ResponseObject<ShowTime>
            {
                Data = newShowTime,
                Message = "ShoTime Cinema Center success",
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

        public async Task<ResponseObject<ShowTime>> Update(Guid Id, ShowTimeUpdateRequest showTime)
        {
            throw new NotImplementedException();
        }
    }
}