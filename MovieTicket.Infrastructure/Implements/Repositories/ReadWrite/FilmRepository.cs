using MovieTicket.Application.DataTransferObjs;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class FilmRepository : IFilmRepository
    {   
        private MovieTicketReadWriteDbContext context;
        public FilmRepository()
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
                context.Films.Remove(film);
                await context.SaveChangesAsync();
            }
            return film;
        }

        public async Task<IQueryable<FilmDto>> GetAllFilm()
        {
            var films = context.Films.Select(film => new FilmDto
            {
                Id = film.Id,
                Name = film.Name,
                EnglishName = film.EnglishName,
                Trailer = film.Trailer,
                Description = film.Description,
                Gerne = film.Gerne,
                Director = film.Director,
                Cast = film.Cast,
                ScreenTypeId = film.ScreenTypeId,
                TranslationTypeId = film.TranslationTypeId,
                Rating = film.Rating,
                StartDate = film.StartDate,
                ReleaseYear = film.ReleaseYear,
                RunningTime = film.RunningTime,
                Status = film.Status,
                Nation = film.Nation,
                Poster = film.Poster,
                Language = film.Language,
                CreatDate = film.CreatDate
            });
            return films;
        }

        public async Task<Film> GetFilmById(Guid id)
        {
            await context.Films.FindAsync(id);
            return await context.Films.FindAsync(id);
        }

        public async Task<Film> UpdateFilm(Film film)
        {
            context.Films.Update(film);
            await context.SaveChangesAsync();
            return film;
        }
    }
}
