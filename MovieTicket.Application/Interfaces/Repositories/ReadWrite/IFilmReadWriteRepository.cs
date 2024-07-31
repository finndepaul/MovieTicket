using MovieTicket.Application.DataTransferObjs;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IFilmReadWriteRepository
    //IFilmReadWriteRepository
    {
        
        Task<Film> CreateFilm(Film film);
        Task<Film> UpdateFilm(Guid id,Film film);
        Task<Film> DeleteFilm(Guid id);
    }
}
