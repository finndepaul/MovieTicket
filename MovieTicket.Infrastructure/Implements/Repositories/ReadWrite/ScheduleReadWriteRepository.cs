using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.Application.DataTransferObjs.Schedule.Request;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class ScheduleReadWriteRepository : IScheduleReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _db;
        private readonly IMapper mapper;

        public ScheduleReadWriteRepository(MovieTicketReadWriteDbContext dbContext, IMapper mapper)
        {
            this._db = dbContext;
            this.mapper = mapper;
        }

        public async Task<ResponseObject<ScheduleDto>> CreateAsync(CreateScheduleRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var film = await _db.Films.FindAsync(request.FilmId, cancellationToken);
                if (request.FilmId == Guid.Empty)
                {
                    return new ResponseObject<ScheduleDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Phim không được để trống!"
                    };
                }
                if (request.StartDate.Date > request.EndDate.Date)
                {
                    return new ResponseObject<ScheduleDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Ngày kết thúc phải lớn hơn ngày bắt đầu"
                    };
                }
                if ((film.StartDate - request.StartDate.Date).TotalDays > 7)
                {
                    return new ResponseObject<ScheduleDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Ngày bắt đầu không thể quá 7 ngày trước ngày khởi chiếu"
                    };
                }
                var schedule = new Schedule
                {
                    FilmId = request.FilmId,
                    StartDate = request.StartDate.Date,
                    EndDate = request.EndDate.Date,
                };
                if (request.StartDate.Date < film.StartDate && request.EndDate.Date <= film.StartDate)
                {
                    schedule.Type = ScheduleType.Early;
                    schedule.Status = ScheduleStatus.ComingSoon;
                }
                if (request.StartDate.Date >= film.StartDate)
                {
                    schedule.Type = ScheduleType.Regular;
                    schedule.Status = ScheduleStatus.Showing;
                }
                await _db.Schedules.AddAsync(schedule, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);
                return new ResponseObject<ScheduleDto>
                {
                    Data = mapper.Map<ScheduleDto>(schedule),
                    Status = StatusCodes.Status201Created,
                    Message = "Tạo lịch chiếu thành công"
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<ScheduleDto>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Error: " + ex.Message
                };
            }
        }

        public async Task<ResponseObject<ScheduleDto>> UpdateAsync(UpdateScheduleRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var schedule = await _db.Schedules.FindAsync(request.Id, cancellationToken);
                var film = await _db.Films.FindAsync(schedule.FilmId, cancellationToken);
                if (request.StartDate > request.EndDate)
                {
                    return new ResponseObject<ScheduleDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Ngày kết thúc phải lớn hơn ngày bắt đầu"
                    };
                }
                if ((film.StartDate.Date - request.StartDate.Date).TotalDays > 7)
                {
                    return new ResponseObject<ScheduleDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Ngày bắt đầu không thể quá 7 ngày trước ngày khởi chiếu"
                    };
                }
                schedule.StartDate = request.StartDate;
                schedule.EndDate = request.EndDate;
                if (request.StartDate < film.StartDate && request.EndDate <= film.StartDate)
                {
                    schedule.Type = ScheduleType.Early;
                    schedule.Status = ScheduleStatus.ComingSoon;
                }
                if (request.StartDate >= film.StartDate)
                {
                    schedule.Type = ScheduleType.Regular;
                    schedule.Status = ScheduleStatus.Showing;
                }
                _db.Schedules.Update(schedule);
                await _db.SaveChangesAsync(cancellationToken);
                return new ResponseObject<ScheduleDto>
                {
                    Data = mapper.Map<ScheduleDto>(schedule),
                    Status = StatusCodes.Status200OK,
                    Message = "Cập nhật lịch chiếu thành công"
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<ScheduleDto>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = $"An error occurred while updating the schedule: {ex.Message}"
                };
            }
        }

        public async Task<ResponseObject<ScheduleDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var scheduleEntity = await _db.Schedules.FindAsync(id);
                if (scheduleEntity == null)
                {
                    return new ResponseObject<ScheduleDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy lịch chiếu"
                    };
                }
                var showtimes = await _db.ShowTimes.FirstOrDefaultAsync(x => x.ScheduleId == id);
                if (showtimes != null)
                {
                    return new ResponseObject<ScheduleDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không thể xóa lịch chiếu đã có suất chiếu"
                    };
                }
                _db.Schedules.Remove(scheduleEntity);
                await _db.SaveChangesAsync(cancellationToken);
                var scheduleDto = mapper.Map<ScheduleDto>(scheduleEntity);
                return new ResponseObject<ScheduleDto>
                {
                    Data = scheduleDto,
                    Status = StatusCodes.Status200OK,
                    Message = "Xóa lịch chiếu thành công"
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<ScheduleDto>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Error:" + ex.Message
                };
            }
        }
    }
}