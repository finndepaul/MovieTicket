using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.DataTransferObjs.ScreenType;
using MovieTicket.Application.DataTransferObjs.TranslationType;

namespace MovieTicket.BlazorServer.Services.Interfaces.IFilmService
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
