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
			var query = _context.Films
				  .Join(_context.FilmScreenTypes, f => f.Id, fst => fst.FilmId, (f, fst) => new { f, fst })
				  .Join(_context.FilmTranslationTypes, x => x.f.Id, ftt => ftt.FilmId, (x, ftt) => new { x.fst, x.f, ftt })
				  .Join(_context.ScreenTypes, x => x.fst.ScreenTypeId, st => st.Id, (x, st) => new { x.f, x.fst, x.ftt, st })
				  .Join(_context.TranslationTypes, x=>x.ftt.TranslationTypeId, tt => tt.Id, (x,tt) => new {x.f ,x.fst ,x.ftt,x.st ,tt})
				  .Select(x => new FilmDto
				  {
					  Id = x.f.Id,
					  Name = x.f.Name,
					  EnglishName = x.f.EnglishName,
					  Trailer = x.f.Trailer,
					  Description = x.f.Description,
					  Gerne = x.f.Gerne,
					  Director = x.f.Director,
					  Cast = x.f.Cast,
					  Rating = x.f.Rating,
					  StartDate = x.f.StartDate,
					  ReleaseYear = x.f.ReleaseYear,
					  RunningTime = x.f.RunningTime,
					  Status = x.f.Status,
					  Nation = x.f.Nation,
					  Poster = x.f.Poster,
					  Language = x.f.Language,
					  CreatDate = x.f.CreatDate,
					  ScreenTypeDtos = (
						from fst in x.f.FilmScreenTypes
						select new ScreenTypeDto
						{
							Id = fst.ScreenType.Id,
							Type = fst.ScreenType.Type
						}).ToList(),
					  TranslationTypeDtos = (
						from ftt in x.f.FilmTranslationTypes
						select new TranslationTypeDto
						{
							Id = ftt.TranslationType.Id,
							Type = ftt.TranslationType.Type
						}).ToList()
				  });

			return query;
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