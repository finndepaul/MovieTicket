using MovieTicket.Application.DataTransferObjs;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IFilmRepository
    //IFilmReadWriteRepository
    {
        Task<IQueryable<FilmDto>> GetAllFilm(); //để trong readonly
        Task<Film> GetFilmById(Guid id); //dùng dto, để trong readonly
        Task<Film> CreateFilm(Film film);
        Task<Film> UpdateFilm(Film film);
        Task<Film> DeleteFilm(Guid id);
    }
}
