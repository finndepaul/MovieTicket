using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Seat;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class SeatReadOnlyRepository : ISeatReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _dBcontext;
        private readonly IMapper _mapper;

        public SeatReadOnlyRepository(MovieTicketReadOnlyDbContext dBcontext, IMapper mapper)
        {
            _dBcontext = dBcontext;
            _mapper = mapper;
        }

        public async Task<IQueryable<SeatDTO>> GetAllAsync(Guid CinemaId)
        {
            var seats = _dBcontext.Seats.Select(c => new SeatDTO
            {
                Id = c.Id,
                CinemaId = (Guid)c.CinemaId,
                CinemaCenterName = c.Cinema.CinemaCenter.Name,
                CinemaName = c.Cinema.Name,
                SeatTypeName = c.SeatType.Name,
                Position = c.Position,
                Status = (SeatStatus)c.Status
            }).AsNoTracking();
            if (!CinemaId.Equals(Guid.Empty))
            {
                seats = seats.Where(x => x.CinemaId == CinemaId);
                if (seats == null)
                {
                    return null;
                }
            }
            return seats.AsQueryable();
        }

        public async Task<ResponseObject<SeatDTO>> GetSeatById(Guid id)
        {
            var seat = await _dBcontext.Seats.FindAsync(id);
            if (seat == null)
            {
                return new ResponseObject<SeatDTO>
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Seat not found.",
                    Data = null
                };
            }
            return new ResponseObject<SeatDTO>
            {
                Status = StatusCodes.Status200OK,
                Message = "Get seat success.",
                Data = _mapper.Map<SeatDTO>(seat)
            };
        }
    }
}