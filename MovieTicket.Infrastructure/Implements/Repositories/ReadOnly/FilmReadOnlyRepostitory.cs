using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class FilmReadOnlyRepostitory : IFilmReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _context;

        public FilmReadOnlyRepostitory(MovieTicketReadOnlyDbContext movieTicketReadOnlyDbContext)
        {
            _context = movieTicketReadOnlyDbContext;
        }

        public async Task<IQueryable<FilmDto>> GetAllFilm()
        {
            // getall film
            var films = _context.Films.Select(film => new FilmDto
            {
                Id = film.Id,
                Name = film.Name,
                EnglishName = film.EnglishName,
                Trailer = film.Trailer,
                Description = film.Description,
                Gerne = film.Gerne,
                Director = film.Director,
                Cast = film.Cast,
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

        public async Task<FilmDto> GetFilmById(Guid id)
        {
            var film = _context.Films.Where(film => film.Id == id).Select(film => new FilmDto
            {
                Id = film.Id,
                Name = film.Name,
                EnglishName = film.EnglishName,
                Trailer = film.Trailer,
                Description = film.Description,
                Gerne = film.Gerne,
                Director = film.Director,
                Cast = film.Cast,
                Rating = film.Rating,
                StartDate = film.StartDate,
                ReleaseYear = film.ReleaseYear,
                RunningTime = film.RunningTime,
                Status = film.Status,
                Nation = film.Nation,
                Poster = film.Poster,
                Language = film.Language,
                CreatDate = film.CreatDate
            }).FirstOrDefault();
            return film;
        }
    }
}