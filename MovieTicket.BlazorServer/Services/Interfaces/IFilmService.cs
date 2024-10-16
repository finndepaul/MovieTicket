using MovieTicket.Application.DataTransferObjs.Film;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IFilmService
    {
        Task<IEnumerable<FilmDto>> GetAllFilms();
        Task<FilmDto> GetById(Guid id);
        Task<FilmDto> CreateFilm(FilmCreateRequest filmCreateRequest);
        Task<FilmDto> UpdateFilm(Guid id, FilmUpdateRequest filmUpdateRequest);
        Task<FilmDto> DeleteFilm(Guid id);
    }
}
