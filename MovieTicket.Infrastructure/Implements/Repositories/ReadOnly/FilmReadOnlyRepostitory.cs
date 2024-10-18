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
				  .GroupBy(x => new { x.f.Id, x.f.Name, x.f.EnglishName, x.f.Trailer, x.f.Description, x.f.Gerne, x.f.Director, x.f.Cast, x.f.Rating, x.f.StartDate, x.f.ReleaseYear, x.f.RunningTime, x.f.Status, x.f.Nation, x.f.Poster, x.f.Language, x.f.CreatDate })
				  .Select(group => new FilmDto()
				  {
					  Id = group.Key.Id,
					  Name = group.Key.Name,
					  EnglishName = group.Key.EnglishName,
					  Trailer = group.Key.Trailer,
					  Description = group.Key.Description,
					  Gerne = group.Key.Gerne,
					  Director = group.Key.Director,
					  Cast = group.Key.Cast,
					  Rating = group.Key.Rating,
					  StartDate = group.Key.StartDate,
					  ReleaseYear = group.Key.ReleaseYear,
					  RunningTime = group.Key.RunningTime,
					  Status = group.Key.Status,
					  Nation = group.Key.Nation,
					  Poster = group.Key.Poster,
					  Language = group.Key.Language,
					  CreatDate = group.Key.CreatDate,
					  ScreenTypeIds = group.Select(g => g.fst.ScreenTypeId).Distinct().ToList(), // Lấy danh sách ScreenTypeIds
					  TranslationTypeIds = group.Select(g => g.ftt.TranslationTypeId).Distinct().ToList() // Lấy danh sách TranslationTypeIds
				  }).AsQueryable();

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