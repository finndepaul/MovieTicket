using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IFilmReadWriteRepository
    //IFilmReadWriteRepository
    {
        Task<Film> CreateFilm(Film film);

        Task<Film> UpdateFilm(Guid id, Film film);

        Task<Film> DeleteFilm(Guid id);
    }
}