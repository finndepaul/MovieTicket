using MovieTicket.Application.DataTransferObjs.UserHome;
using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IUserHomeReadOnlyRepository
    {
        Task<IQueryable<UserHomeDto>> GetAllFilmForUserHome();
    }
}
