using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class CinemaCenterReadWriteRepository : ICinemaCenterReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _movieTicket;

        public CinemaCenterReadWriteRepository(MovieTicketReadWriteDbContext movieTicket)
        {
            _movieTicket = movieTicket;
        }

        public async Task<ResponseObject<CinemaCenter>> Create(CinemaCenter cinemaCenter)
        {
            // Check tồn tại
            var cinemaCenterItem = await _movieTicket.CinemaCenters.FirstOrDefaultAsync(x => x.Name == cinemaCenter.Name && x.Address == cinemaCenter.Address);
            if (cinemaCenter == null)
            {
                return new ResponseObject<CinemaCenter>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Cinema Center is null",
                    Data = null
                };
            }
            // Check tồn tại
            if (cinemaCenterItem != null)
            {
                return new ResponseObject<CinemaCenter>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Cinema Center is exist",
                    Data = null
                };
            }
            await _movieTicket.AddAsync(cinemaCenter);
            await _movieTicket.SaveChangesAsync();
            return new ResponseObject<CinemaCenter>
            {
                Status = StatusCodes.Status200OK,
                Message = "Create Cinema Center success",
                Data = cinemaCenter
            };
        }

        public async Task<ResponseObject<CinemaCenter>> Delete(Guid id)
        {
            var cinemaCenter = await _movieTicket.CinemaCenters.FindAsync(id);
            if (cinemaCenter == null)
            {
                return new ResponseObject<CinemaCenter>
                {
                    Data = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Cinema Center is not exist"
                };
            }
            _movieTicket.CinemaCenters.Remove(cinemaCenter);
            await _movieTicket.SaveChangesAsync();
            return new ResponseObject<CinemaCenter>
            {
                Data = cinemaCenter,
                Status = StatusCodes.Status200OK,
                Message = "Delete Cinema Center success"
            };
        }

        public async Task<ResponseObject<CinemaCenter>> Update(Guid id, CinemaCenterUpdateRequest cinemaCenter)
        {
            var cinemaCenterItem = await _movieTicket.CinemaCenters.FindAsync(id);
            // check tồn tại
            if (cinemaCenterItem == null)
            {
                return new ResponseObject<CinemaCenter>
                {
                    Data = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Cinema Center is not exist"
                };
            }
            cinemaCenterItem.Name = cinemaCenter.Name;
            cinemaCenterItem.Address = cinemaCenter.Address;
            _movieTicket.CinemaCenters.Update(cinemaCenterItem);
            await _movieTicket.SaveChangesAsync();
            return new ResponseObject<CinemaCenter>
            {
                Data = cinemaCenterItem,
                Status = StatusCodes.Status200OK,
                Message = "Update Cinema Center success"
            };
        }
    }
}