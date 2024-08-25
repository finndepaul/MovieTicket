using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<IQueryable<ShowTimeDto>> GetAll(string? name)
        {
            var showTimes = (from showTime in _db.ShowTimes
                             join cinema in _db.Cinemas on showTime.CinemaId equals cinema.Id
                             join cinemaCenter in _db.CinemaCenters on showTime.CinemaCenterId equals cinemaCenter.Id
                             join film in _db.Films on showTime.FilmId equals film.Id
                             join schedule in _db.Schedules on showTime.ScheduleId equals schedule.Id
                             join screenType in _db.ScreenTypes on showTime.ScreenTypeId equals screenType.Id
                             join translationType in _db.TranslationTypes on showTime.TranslationTypeId equals translationType.Id
                             select new ShowTimeDto
                             {
                                 Id = showTime.Id,
                                 CinemaName = cinema.Name,
                                 CinemaCenterName = cinemaCenter.Name,
                                 FilmName = film.Name,
                                 StartDate = schedule.StartDate,
                                 ScreenTypeName = screenType.Type,
                                 TranslationTypeName = translationType.Type,
                                 StartTime = showTime.StartTime,
                                 EndTime = showTime.EndTime,
                                 ShowtimeDate = showTime.ShowtimeDate,
                                 Desciption = showTime.Desciption,
                                 Status = showTime.Status
                             }).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                showTimes = showTimes.Where(x => x.FilmName.Contains(name));
            }
            return showTimes;
        }

        public async Task<ResponseObject<ShowTimeDto>> GetById(Guid id)
        {
            var showTimes = await (from showTime in _db.ShowTimes
                            join cinema in _db.Cinemas on showTime.CinemaId equals cinema.Id
                            join cinemaCenter in _db.CinemaCenters on showTime.CinemaCenterId equals cinemaCenter.Id
                            join film in _db.Films on showTime.FilmId equals film.Id
                            join schedule in _db.Schedules on showTime.ScheduleId equals schedule.Id
                            join screenType in _db.ScreenTypes on showTime.ScreenTypeId equals screenType.Id
                            join translationType in _db.TranslationTypes on showTime.TranslationTypeId equals translationType.Id
                            where showTime.Id == id
                            select new ShowTimeDto
                            {
                                Id = showTime.Id,
                                CinemaName = cinema.Name,
                                CinemaCenterName = cinemaCenter.Name,
                                FilmName = film.Name,
								StartDate = schedule.StartDate,
								ScreenTypeName = screenType.Type,
                                TranslationTypeName = translationType.Type,
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
                    Message = "ShowTime not found",
                    Data = null
                };
            }
            return new ResponseObject<ShowTimeDto>
            {
                Data = showTimes,
                Status = StatusCodes.Status200OK,
                Message = "Get ShowTime success"
            };
        }
    }
}
