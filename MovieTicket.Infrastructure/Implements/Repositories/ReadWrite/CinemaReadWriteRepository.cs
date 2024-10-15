using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Banner;
using MovieTicket.Application.DataTransferObjs.Cinema;
using MovieTicket.Application.DataTransferObjs.Cinema.Request;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using MovieTicket.Infrastructure.Implements.Repositories.ReadOnly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class CinemaReadWriteRepository : ICinemaReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _context;

        public CinemaReadWriteRepository(MovieTicketReadWriteDbContext movieTicket)
        {
            _context = movieTicket;
        }

        public async Task<ResponseObject<CinemaDto>> Create(CinemaCreateRequest request)
        {
            try
            {
                var lst = _context.Cinemas.Where(x => x.CinemaCenterId == request.CinemaCenterId).ToList();

                if (lst.Exists(x => x.Name == request.Name))
                {
                    return new ResponseObject<CinemaDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Tên phòng chiếu đã tồn tại"
                    };
                }

                var cinema = new Cinema
                {
                    Name = request.Name,
                    CinemaTypeId = request.CinemaTypeId,
                    CinemaCenterId = request.CinemaCenterId,
                    Column = request.Column,
                    Row = request.Row,
                    MaxSeatCapacity = request.Column * request.Row,
                    Description = request.Description,
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.MinValue
                };
                await _context.Cinemas.AddAsync(cinema);
                await _context.SaveChangesAsync();
                return new ResponseObject<CinemaDto>
                {
                    Data = new CinemaDto
                    {
                        Id = cinema.Id,
                        Name = cinema.Name,
                        CinemaTypeName = _context.CinemaTypes.Find(cinema.CinemaTypeId).Name,
                        CinemaCenterName = _context.CinemaCenters.Find(cinema.CinemaCenterId).Name,
                        Column = cinema.Column,
                        Row = cinema.Row,
                        MaxSeatCapacity = cinema.MaxSeatCapacity,
                        Description = cinema.Description,
                        CreateTime = cinema.CreateTime,
                        UpdateTime = cinema.UpdateTime
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Tạo phòng chiếu thành công"
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<CinemaDto>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = e.Message
                };
            }
        }

        public async Task<ResponseObject<Cinema>> HardDelete(Guid id)
        {
            try
            {
                var model = await _context.Cinemas.FindAsync(id);
                if (model == null)
                {
                    return new ResponseObject<Cinema>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy phòng chiếu",
                        Data = null
                    };
                }
                _context.Cinemas.Remove(model);
                await _context.SaveChangesAsync();
                return new ResponseObject<Cinema>
                {
                    Data = null,
                    Status = StatusCodes.Status200OK,
                    Message = "Xóa thành công"
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<Cinema>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = e.Message
                };
            }
        }

        public async Task<ResponseObject<CinemaDto>> Update(CinemaUpdateRequest request)
        {
            try
            {
                var cinema = await _context.Cinemas.FindAsync(request.Id);
                if (cinema == null)
                {
                    return new ResponseObject<CinemaDto>
                    {
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy phòng chiếu",
                        Data = null
                    };
                }
                cinema.Name = request.Name;
                cinema.CinemaTypeId = request.CinemaTypeId;
                cinema.Column = request.Column;
                cinema.Row = request.Row;
                cinema.MaxSeatCapacity = request.Column * request.Row;
                cinema.Description = request.Description;
                cinema.UpdateTime = DateTime.Now;
                _context.Cinemas.Update(cinema);
                await _context.SaveChangesAsync();
                return new ResponseObject<CinemaDto>
                {
                    Data = new CinemaDto
                    {
                        Id = cinema.Id,
                        Name = cinema.Name,
                        CinemaTypeName = _context.CinemaTypes.Find(cinema.CinemaTypeId).Name,
                        CinemaCenterName = _context.CinemaCenters.Find(cinema.CinemaCenterId).Name,
                        Column = cinema.Column,
                        Row = cinema.Row,
                        MaxSeatCapacity = cinema.MaxSeatCapacity,
                        Description = cinema.Description,
                        CreateTime = cinema.CreateTime,
                        UpdateTime = cinema.UpdateTime
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Update phòng chiếu thành công!"
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<CinemaDto>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = e.Message
                };
            }
        }
    }
}