using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.ValueObjs.Paginations;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFilmReadOnlyRepository
    {
        Task<IQueryable<FilmDto>> GetAllFilm();

        Task<FilmDto> GetFilmById(Guid id);

        Task<PageList<FilmDto>> GetFilmPageList(PagingParameters pagingParameters);

        Task<PageList<FilmDto>> FilterFilms(string? name, int? releaseYear, DateTime? createDate, DateTime? startDate, PagingParameters pagingParameters);
    }
}