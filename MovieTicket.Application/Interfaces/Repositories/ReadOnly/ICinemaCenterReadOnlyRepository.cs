using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface ICinemaCenterReadOnlyRepository
    {
        Task<IQueryable<CinemaCenterDto>> GetAll();
        Task<CinemaCenter> GetById(Guid id);
    }
}
