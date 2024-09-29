using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.UserHome;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class UserHomeReadOnlyRepository : IUserHomeReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _context;

        public UserHomeReadOnlyRepository(MovieTicketReadOnlyDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<UserHomeDto>> GetAllFilmForUserHome()
        {
            return _context.Films
                .Select(x => new UserHomeDto
                {
                    Id = x.Id,
                    Poster = x.Poster,
                    Name = x.Name,
                    Gerne = x.Gerne,
                    RunningTime = x.RunningTime
                })
                .AsNoTracking();
        }
    }
}
