using MovieTicket.Application.DataTransferObjs.Film;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFilmReadOnlyRepository
    {
        Task<IQueryable<FilmDto>> GetAllFilm(); //để trong readonly

        Task<FilmDto> GetFilmById(Guid id); //dùng dto, để trong readonly
    }
}