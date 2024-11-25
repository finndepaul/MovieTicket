using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.DataTransferObjs.ScreenType;
using MovieTicket.Application.DataTransferObjs.TranslationType;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.Paginations;
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

        public async Task<PageList<FilmDto>> FilterFilms(string? name, int? releaseYear, DateTime? createDate, DateTime? startDate, PagingParameters pagingParameters)
        {
            var query = _context.Films.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Name.Contains(name));
            }

            if (releaseYear.HasValue)
            {
                query = query.Where(x => x.ReleaseYear == releaseYear);
            }

            if (createDate.HasValue)
            {
                var startOfDay = createDate.Value.Date;
                var endOfDay = startOfDay.AddDays(1);
                query = query.Where(x => x.CreatDate >= startOfDay && x.CreatDate < endOfDay);
            }

            if (startDate.HasValue)
            {
                var startOfDay = startDate.Value.Date;
                var endOfDay = startOfDay.AddDays(1);
                query = query.Where(x => x.StartDate >= startOfDay && x.StartDate < endOfDay);
            }


            var count = await query.CountAsync();
            var items = await query
                .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .Select(f => new FilmDto
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
                    Nation = f.Nation,
                    Poster = f.Poster,
                    Language = f.Language,
                    CreatDate = f.CreatDate,
                    ScreenTypeDtos = f.FilmScreenTypes.Select(fst => new ScreenTypeDto
                    {
                        Id = fst.ScreenType.Id,
                        Type = fst.ScreenType.Type
                    }).ToList(),
                    TranslationTypeDtos = f.FilmTranslationTypes.Select(ftt => new TranslationTypeDto
                    {
                        Id = ftt.TranslationType.Id,
                        Type = ftt.TranslationType.Type
                    }).ToList()
                }).ToListAsync();

            return new PageList<FilmDto>(items, count, pagingParameters.PageNumber, pagingParameters.PageSize);
        }

        public async Task<IQueryable<FilmDto>> GetAllFilm()
		{
			var film = (
				from f in _context.Films
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
				.AsNoTracking().OrderByDescending(f => f.CreatDate).AsQueryable();
			return film;
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

        public async Task<PageList<FilmDto>> GetFilmPageList(PagingParameters pagingParameters)
        {
            var query = (
                from f in _context.Films
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
                .AsNoTracking();

            var count = await query.CountAsync();
            var items = await query
                .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .ToListAsync();

            return new PageList<FilmDto>(items, count, pagingParameters.PageNumber, pagingParameters.PageSize);
        }

    }
}