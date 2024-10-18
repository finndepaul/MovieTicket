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
			//         // getall film
			//         var films = _context.Films.Select(film => new FilmDto
			//         {
			//             Id = film.Id,
			//             Name = film.Name,
			//             EnglishName = film.EnglishName,
			//             Trailer = film.Trailer,
			//             Description = film.Description,
			//             Gerne = film.Gerne,
			//             Director = film.Director,
			//             Cast = film.Cast,
			//             Rating = film.Rating,
			//             StartDate = film.StartDate,
			//             ReleaseYear = film.ReleaseYear,
			//             RunningTime = film.RunningTime,
			//             Status = film.Status,
			//             Nation = film.Nation,
			//             Poster = film.Poster,
			//             Language = film.Language,
			//             CreatDate = film.CreatDate,
			//             ScreenTypeIds = new List<Guid>(),
			//});
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