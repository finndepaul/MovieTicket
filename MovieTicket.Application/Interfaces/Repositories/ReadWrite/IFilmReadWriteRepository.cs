using MovieTicket.Application.DataTransferObjs;
using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IFilmReadWriteRepository
    {
        Task<ResponseObject<FilmDto>> CreateFilm(FilmCreateRequest filmCreateRequest);
        Task<ResponseObject<FilmDto>> UpdateFilm(Guid id, FilmUpdateRequest filmUpdateRequest);
        Task<ResponseObject<FilmDto>> DeleteFilm(Guid id);
    }
}
