using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.ValueObjs.Paginations;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IFilmService
    {
        Task<IEnumerable<FilmDto>> GetAllFilms();
        Task<PageList<FilmDto>> GetAllPaging(PagingParameters pagingParameters);
        Task<FilmDto> GetById(Guid id);
        Task<FilmDto> CreateFilm(FilmCreateRequest filmCreateRequest);
        Task<FilmDto> UpdateFilm(Guid id, FilmUpdateRequest filmUpdateRequest);
        Task<FilmDto> DeleteFilm(Guid id);
        Task<PageList<FilmDto>> GetFiltering(string? name, int? releaseYear, DateTime? createDate, DateTime? startDate, PagingParameters pagingParameters);

    }
}
