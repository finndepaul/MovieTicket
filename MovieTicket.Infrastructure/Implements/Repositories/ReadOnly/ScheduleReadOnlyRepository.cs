﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class ScheduleReadOnlyRepository : IScheduleReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext dbContext;
        private readonly IMapper mapper;

        public ScheduleReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IQueryable<ScheduleDto>> GetAllAsync()
        {
            // Truy vấn để lấy dữ liệu từ bảng Schedules và Films, sau đó ánh xạ vào ScheduleDto
            var scheduleDtos = from schedule in dbContext.Schedules
                               join film in dbContext.Films on schedule.FilmId equals film.Id
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
            var scheduleDtos = from schedule in dbContext.Schedules
                               join film in dbContext.Films on schedule.FilmId equals film.Id
                               where schedule.FilmId == filmId
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

            // Kiểm tra nếu không có lịch chiếu nào cho FilmId thì ném ra ngoại lệ
            if (!scheduleDtos.Any())
            {
                throw new InvalidOperationException($"No schedules found for Film ID {filmId}.");
            }

            // Trả về danh sách lịch chiếu
            return scheduleDtos;
        }

        // Phương thức lấy lịch chiếu theo Id
        public async Task<ScheduleDto?> GetByIdAsync(Guid id)
        {
            // Kiểm tra nếu Id rỗng thì ném ra ngoại lệ
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid ID.", nameof(id));
            }

            // Truy vấn để lấy dữ liệu từ bảng Schedules và Films theo Id, sau đó ánh xạ vào ScheduleDto
            var scheduleDto = await (from schedule in dbContext.Schedules
                                     join film in dbContext.Films on schedule.FilmId equals film.Id
                                     where schedule.Id == id
                                     select new ScheduleDto
                                     {
                                         Id = schedule.Id,
                                         FilmId = schedule.FilmId,
                                         StartDate = schedule.StartDate,
                                         EndDate = schedule.EndDate,
                                         Type = schedule.Type,
                                         Status = schedule.Status,
                                         FilmName = film.Name // Lấy tên phim
                                     }).FirstOrDefaultAsync();

            // Kiểm tra nếu không có lịch chiếu nào cho Id thì ném ra ngoại lệ
            if (scheduleDto == null)
            {
                throw new InvalidOperationException($"No schedule found for ID {id}.");
            }

            // Trả về lịch chiếu
            return scheduleDto;
        }
    }
}
