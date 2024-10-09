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
        private readonly MovieTicketReadWriteDbContext dbContext;
        private readonly IMapper mapper;

        public ScheduleReadWriteRepository(MovieTicketReadWriteDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        // Phương thức tạo mới một lịch chiếu
        public async Task<ResponseObject<ScheduleDto>> CreateAsync(CreateScheduleRequest createScheduleRequest)
        {
            try
            {
                // Kiểm tra trùng lặp lịch chiếu
                bool isDuplicate = await dbContext.Schedules.AnyAsync(s =>
                    s.FilmId == createScheduleRequest.FilmId &&
                    ((createScheduleRequest.StartDate >= s.StartDate && createScheduleRequest.StartDate <= s.EndDate) ||
                    (createScheduleRequest.EndDate >= s.StartDate && createScheduleRequest.EndDate <= s.EndDate) ||
                    (createScheduleRequest.StartDate <= s.StartDate && createScheduleRequest.EndDate >= s.EndDate)));

                if (isDuplicate)
                {
                    return new ResponseObject<ScheduleDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Schedule for the given film and date range already exists."
                    };
                }

                // Ánh xạ CreateScheduleRequest sang Schedule entity
                var scheduleEntity = mapper.Map<Schedule>(createScheduleRequest);
                // Thiết lập trạng thái và loại lịch chiếu ban đầu
                scheduleEntity.Status = ScheduleStatus.ComingSoon;
                scheduleEntity.Type = ScheduleType.Early;
                // Thêm lịch chiếu vào cơ sở dữ liệu
                await dbContext.Schedules.AddAsync(scheduleEntity);
                await dbContext.SaveChangesAsync();

                // Ánh xạ Schedule entity sang ScheduleDto
                var scheduleDto = mapper.Map<ScheduleDto>(scheduleEntity);
                return new ResponseObject<ScheduleDto>
                {
                    Data = scheduleDto,
                    Status = StatusCodes.Status201Created,
                    Message = "Schedule created successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<ScheduleDto>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = $"An error occurred while creating the schedule: {ex.Message}"
                };
            }
        }

        // Phương thức cập nhật một lịch chiếu
        public async Task<ResponseObject<ScheduleDto?>> UpdateAsync(UpdateScheduleRequest updateScheduleRequest)
        {
            try
            {
                // Tìm lịch chiếu theo id
                var scheduleEntity = await dbContext.Schedules.FindAsync(updateScheduleRequest.Id);
                if (scheduleEntity == null)
                {
                    return new ResponseObject<ScheduleDto?>
                    {
                        Data = null,
                        Status = StatusCodes.Status404NotFound,
                        Message = "Schedule not found"
                    };
                }
                // Ánh xạ UpdateScheduleRequest sang Schedule entity
                mapper.Map(updateScheduleRequest, scheduleEntity);
                // Thiết lập lại trạng thái và loại lịch chiếu
                scheduleEntity.Status = ScheduleStatus.ComingSoon;
                scheduleEntity.Type = ScheduleType.Early;
                // Cập nhật lịch chiếu trong cơ sở dữ liệu
                dbContext.Schedules.Update(scheduleEntity);
                await dbContext.SaveChangesAsync();

                // Ánh xạ Schedule entity sang ScheduleDto
                var scheduleDto = mapper.Map<ScheduleDto>(scheduleEntity);
                return new ResponseObject<ScheduleDto?>
                {
                    Data = scheduleDto,
                    Status = StatusCodes.Status200OK,
                    Message = "Schedule updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<ScheduleDto?>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = $"An error occurred while updating the schedule: {ex.Message}"
                };
            }
        }

        // Phương thức xóa một lịch chiếu
        public async Task<ResponseObject<ScheduleDto?>> DeleteAsync(Guid id)
        {
            try
            {
                // Tìm lịch chiếu theo id
                var scheduleEntity = await dbContext.Schedules.FindAsync(id);
                if (scheduleEntity == null)
                {
                    return new ResponseObject<ScheduleDto?>
                    {
                        Data = null,
                        Status = StatusCodes.Status404NotFound,
                        Message = "Schedule not found"
                    };
                }

                // Xóa lịch chiếu khỏi cơ sở dữ liệu
                dbContext.Schedules.Remove(scheduleEntity);
                await dbContext.SaveChangesAsync();

                // Ánh xạ Schedule entity sang ScheduleDto
                var scheduleDto = mapper.Map<ScheduleDto>(scheduleEntity);
                return new ResponseObject<ScheduleDto?>
                {
                    Data = scheduleDto,
                    Status = StatusCodes.Status200OK,
                    Message = "Schedule deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<ScheduleDto?>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = $"An error occurred while deleting the schedule: {ex.Message}"
                };
            }
        }
    }
}
