using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.CinemaCenter;
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
            var cinemaCenterItem = await _movieTicket.CinemaCenters.FirstOrDefaultAsync(x => x.Name == cinemaCenter.Name && x.Address == cinemaCenter.Address);
            if (cinemaCenter == null)
            {
                return null;
            }
            if (cinemaCenterItem != null)
            {
                return null;
            }
            await _movieTicket.AddAsync(cinemaCenter);
            await _movieTicket.SaveChangesAsync();
            return cinemaCenter;
        }

        public async Task<CinemaCenter> Delete(Guid id)
        {
            var cinemaCenter = await _movieTicket.CinemaCenters.FindAsync(id);
            if (cinemaCenter == null)
            {
                return null;
            }
            _movieTicket.CinemaCenters.Remove(cinemaCenter);
            await _movieTicket.SaveChangesAsync();
            return cinemaCenter;
        }

        public async Task<CinemaCenter> Update(Guid id, CinemaCenterUpdateRequest cinemaCenter)
        {
            var cinemaCenterItem = await _movieTicket.CinemaCenters.FindAsync(id);
            if (cinemaCenterItem == null)
            {
                return null;
            }
            cinemaCenterItem.Name = cinemaCenter.Name;
            cinemaCenterItem.Address = cinemaCenter.Address;
            _movieTicket.CinemaCenters.Update(cinemaCenterItem);
            await _movieTicket.SaveChangesAsync();
            return cinemaCenterItem;
        }
    }
}
