using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface ICinemaCenterReadWriteRepository
    {
        Task<CinemaCenter> Create(CinemaCenter cinemaCenter);
        Task<CinemaCenter> Update(Guid Id,CinemaCenterUpdateRequest cinemaCenter);
        Task<CinemaCenter> Delete(Guid id);
    }
}
