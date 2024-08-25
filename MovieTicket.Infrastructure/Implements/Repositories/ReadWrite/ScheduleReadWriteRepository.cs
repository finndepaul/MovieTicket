using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
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

        public async Task<ResponseObject<ScheduleDto>> CreateAsync(CreateScheduleRequest createScheduleRequest)
        {
            try
            {
                var scheduleEntity = mapper.Map<Schedule>(createScheduleRequest);
                await dbContext.Schedules.AddAsync(scheduleEntity);
                await dbContext.SaveChangesAsync();

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

        public async Task<ResponseObject<ScheduleDto?>> UpdateAsync(Guid id, UpdateScheduleRequest updateScheduleRequest)
        {
            try
            {
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

                mapper.Map(updateScheduleRequest, scheduleEntity);
                dbContext.Schedules.Update(scheduleEntity);
                await dbContext.SaveChangesAsync();

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

        public async Task<ResponseObject<ScheduleDto?>> DeleteAsync(Guid id)
        {
            try
            {
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

                dbContext.Schedules.Remove(scheduleEntity);
                await dbContext.SaveChangesAsync();

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
