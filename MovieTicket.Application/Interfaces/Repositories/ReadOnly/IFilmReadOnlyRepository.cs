using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IFilmReadOnlyRepository
    {
        Task<IQueryable<FilmDto>> GetAllFilm(); //để trong readonly
        Task<FilmDto> GetFilmById(Guid id); //dùng dto, để trong readonly
    }
}
