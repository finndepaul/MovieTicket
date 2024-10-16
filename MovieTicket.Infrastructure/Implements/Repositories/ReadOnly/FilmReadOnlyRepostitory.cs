using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.DataTransferObjs.ScreenType;
using MovieTicket.Application.DataTransferObjs.TranslationType;
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
            var films = _context.Films.Where(s=>s.Status != FilmStatus.Ended).Select(film => new FilmDto
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
            var film = await (
                from f in _context.Films
                where f.Id == id
                select new FilmDto
                {
                    Id = f.Id,
                    Name = f.Name,
                    EnglishName = f.EnglishName,
                    Trailer = f.Trailer,
                    Description = f.Description,
                    Gerne = f.Gerne,
                    Director = f.Director,
                    Cast = f.Cast,
                    Rating = f.Rating,
                    StartDate = f.StartDate,
                    ReleaseYear = f.ReleaseYear,
                    RunningTime = f.RunningTime,
                    Status = f.Status,
                    Nation = f.Nation,
                    Poster = f.Poster,
                    Language = f.Language,
                    CreatDate = f.CreatDate,
                    ScreenTypeDtos = (
                        from fst in f.FilmScreenTypes
                        select new ScreenTypeDto
                        {
                            Id = fst.ScreenType.Id,
                            Type = fst.ScreenType.Type
                        }).ToList(),
                    TranslationTypeDtos = (
                        from ftt in f.FilmTranslationTypes
                        select new TranslationTypeDto
                        {
                            Id = ftt.TranslationType.Id,
                            Type = ftt.TranslationType.Type
                        }).ToList()
                })
                .FirstOrDefaultAsync();

            return film;
        }
    }
}