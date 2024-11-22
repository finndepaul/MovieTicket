using MovieTicket.Application.DataTransferObjs.Cinema;
using MovieTicket.Application.ValueObjs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface ICinemaReadOnlyRepository
    {
        Task<IQueryable<CinemaDto>> GetAllAsync(string? cinemaCenterName);

        Task<ResponseObject<CinemaDto>> GetCinemaById(Guid id);
        Task<IQueryable<CinemaDto>> GetAll();
    }
}