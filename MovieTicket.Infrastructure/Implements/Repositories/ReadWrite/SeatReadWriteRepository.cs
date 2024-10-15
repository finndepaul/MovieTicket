using AutoMapper;
using Microsoft.AspNetCore.Http;
using MovieTicket.Application.DataTransferObjs.Seat;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class SeatReadWriteRepository : ISeatReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _dBcontext;

        public SeatReadWriteRepository(MovieTicketReadWriteDbContext dBcontext)
        {
            _dBcontext = dBcontext;
        }

        private readonly IMapper _mapper;

        public async Task<ResponseObject<SeatDTO>> CreateAsync(SeatCreateRequest request, string position)
        {
            try
            {
                var lst = _dBcontext.Seats.Where(x => x.CinemaId == request.CinemaId);
                var seat = new Seat
                {
                    CinemaId = request.CinemaId,
                    SeatTypeId = null,
                    Position = position,
                    Status = SeatStatus.Available,
                };
                await _dBcontext.Seats.AddAsync(seat);
                await _dBcontext.SaveChangesAsync();
                return new ResponseObject<SeatDTO>
                {
                    Data = new SeatDTO
                    {
                        Id = seat.Id,
                        CinemaName = _dBcontext.Cinemas.Find(seat.CinemaId).Name,
                        SeatTypeName = _dBcontext.SeatTypes.Find(seat.SeatTypeId).Name,
                        Position = seat.Position,
                        Status = seat.Status.Value
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Thêm ghế thành công"
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<SeatDTO>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = e.Message
                };
            }
        }

        public async Task<ResponseObject<SeatDTO>> UpdateAsync(SeatUpdateRequest request)
        {
            try
            {
                var seat = await _dBcontext.Seats.FindAsync(request.Id);
                if (seat == null)
                {
                    return new ResponseObject<SeatDTO>
                    {
                        Data = null,
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy ghế"
                    };
                }
                seat.SeatTypeId = request.SeatTypeId;
                seat.Status = (SeatStatus?)request.Status;
                _dBcontext.Seats.Update(seat);
                await _dBcontext.SaveChangesAsync();
                return new ResponseObject<SeatDTO>
                {
                    Data = new SeatDTO
                    {
                        Id = seat.Id,
                        CinemaName = _dBcontext.Cinemas.Find(seat.CinemaId).Name,
                        SeatTypeName = _dBcontext.SeatTypes.Find(seat.SeatTypeId).Name,
                        Position = seat.Position,
                        Status = seat.Status.Value
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Cập nhật ghế thành công"
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<SeatDTO>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = e.Message
                };
            }
        }

        public async Task<ResponseObject<Seat>> HardDelete(Guid id)
        {
            try
            {
                var seat = await _dBcontext.Seats.FindAsync(id);
                if (seat == null)
                {
                    return new ResponseObject<Seat>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy ghế",
                        Data = null
                    };
                }
                _dBcontext.Seats.Remove(seat);
                await _dBcontext.SaveChangesAsync();
                return new ResponseObject<Seat>
                {
                    Data = null,
                    Status = StatusCodes.Status200OK,
                    Message = "Xóa thành công"
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<Seat>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = e.Message
                };
            }
        }
    }
}