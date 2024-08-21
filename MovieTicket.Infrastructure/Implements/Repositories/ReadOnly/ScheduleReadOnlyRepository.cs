using AutoMapper;
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

            if (!scheduleDtos.Any())
            {
                throw new InvalidOperationException("No schedules found.");
            }

            return scheduleDtos;
        }

        public async Task<IQueryable<ScheduleDto>> GetByFilmIdAsync(Guid filmId)
        {
            if (filmId == Guid.Empty)
            {
                throw new ArgumentException("Invalid Film ID.", nameof(filmId));
            }

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

            if (!scheduleDtos.Any())
            {
                throw new InvalidOperationException($"No schedules found for Film ID {filmId}.");
            }

            return scheduleDtos;
        }

        public async Task<ScheduleDto?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid ID.", nameof(id));
            }

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

            if (scheduleDto == null)
            {
                throw new InvalidOperationException($"No schedule found for ID {id}.");
            }

            return scheduleDto;
        }
    }
}
