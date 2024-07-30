using MovieTicket.Application.DataTransferObjs;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
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
    public class FilmReadWriteRepository : IFilmReadWriteRepository
    {   
        private MovieTicketReadWriteDbContext context;
        public FilmReadWriteRepository()
        {
            context = new MovieTicketReadWriteDbContext();
        }
        public async Task<Film> CreateFilm(Film film)
        {
            await context.Films.AddAsync(film);
            await context.SaveChangesAsync();
            return film;
        }

        public async Task<Film> DeleteFilm(Guid id)
        {
            var film = await context.Films.FindAsync(id);
            if (film != null)
            {   
                film.Status = FilmStatus.Ended;
                context.Films.Update(film);
                await context.SaveChangesAsync();
            }
            return film;
        }
       

        public async Task<Film> UpdateFilm(Guid Id,Film film)
        {
            var data = await context.Films.FindAsync(Id);
            if (data != null)
            {
                data.Name = film.Name;
                data.EnglishName = film.EnglishName;
                data.Trailer = film.Trailer;
                data.Description = film.Description;
                data.Gerne = film.Gerne;
                data.Director = film.Director;
                data.Cast = film.Cast;
                data.ScreenTypeId = film.ScreenTypeId;
                data.TranslationTypeId = film.TranslationTypeId;
                data.Rating = film.Rating;
                data.StartDate = film.StartDate;
                data.ReleaseYear = film.ReleaseYear;
                data.RunningTime = film.RunningTime;
                data.Status = film.Status;
                data.Nation = film.Nation;
                data.Poster = film.Poster;
                data.Language = film.Language;
                context.Films.Update(film);
                await context.SaveChangesAsync();
                return film;
            }
            else
            {
                return null;
            } 
        }
    }
}

