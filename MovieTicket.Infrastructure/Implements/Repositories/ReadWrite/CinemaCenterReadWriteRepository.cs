using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class CinemaCenterReadWriteRepository : ICinemaCenterReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _movieTicket;

        public CinemaCenterReadWriteRepository(MovieTicketReadWriteDbContext movieTicket)
        {
            _movieTicket = movieTicket;
        }
        public async Task<CinemaCenter> Create(CinemaCenter cinemaCenter)
        {
            await _movieTicket.AddAsync(cinemaCenter);
            await _movieTicket.SaveChangesAsync();
            return cinemaCenter;
        }

        public async Task<CinemaCenter> Delete(Guid id)
        {
            var cinemaCenter = await _movieTicket.CinemaCenters.FindAsync(id);
            _movieTicket.CinemaCenters.Remove(cinemaCenter);
            await _movieTicket.SaveChangesAsync();
            return cinemaCenter;
        }

        public async Task<CinemaCenter> Update(CinemaCenter cinemaCenter)
        {
            _movieTicket.CinemaCenters.Update(cinemaCenter);
            await _movieTicket.SaveChangesAsync();
            return cinemaCenter;
        }
    }

}
