﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Cinema;
using MovieTicket.Application.DataTransferObjs.Cinema.Request;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;

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
                if (request.Name.Length < 5 || request.Name.Length > 100)
                {
                    return new ResponseObject<CinemaDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Tên phòng chiếu phải có ít nhất 5 ký tự và tối đa 100 ký tự"
                    };
                }
                if (request.Name == null)
                {
                    return new ResponseObject<CinemaDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Tên không được để trống"
                    };
                }
                if (request.Column < 2 || request.Column > 30)
                {
                    return new ResponseObject<CinemaDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Số cột nằm trong khoảng 2 -> 30"
                    };
                }
                if (request.Row < 2 || request.Row > 26)
                {
                    return new ResponseObject<CinemaDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Số hàng nằm trong khoảng 2 -> 26"
                    };
                }
                if (request.CinemaTypeId == null)
                {
                    return new ResponseObject<CinemaDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Chưa chọn loại phòng chiếu"
                    };
                }
                if (request.CinemaCenterId == null)
                {
                    return new ResponseObject<CinemaDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Chưa chọn rạp chiếu"
                    };
                }
                if (request.Description == null)
                {
                    return new ResponseObject<CinemaDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Chưa nhập mô tả"
                    };
                }
                if (request.Description.Length < 1 || request.Description.Length > 255)
                {
                    return new ResponseObject<CinemaDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Mô tả phải có ít nhất 1 ký tự và tối đa 255 ký tự"
                    };
                }

                var cinema = new Cinema
                {
                    Name = request.Name,
                    CinemaTypeId = Guid.Parse(request.CinemaTypeId),
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
                string position = "";
                for (int x = 1; x <= request.Row; x++)
                {
                    position = AlphabeticalOrder(x - 1);
                    for (int y = 1; y <= request.Column; y++)
                    {
                        position += y;
                        var seat = new Seat
                        {
                            CinemaId = cinema.Id,
                            SeatTypeId = _context.SeatTypes.Where(x => x.Name == "Normal").FirstOrDefault().Id,
                            Position = position,
                            Row = x,
                            Column = y,
                            Status = SeatStatus.Available,
                            Selection = SeatSelection.None,
                        };
                        await _context.Seats.AddAsync(seat);
                        position = AlphabeticalOrder(x - 1);
                    }
                    position = "";
                }
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

                var lstShowTime = await _context.ShowTimes.Where(x => x.CinemaId == id).ToListAsync();

                if (lstShowTime.Count > 0)
                {
                    return new ResponseObject<Cinema>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không thể xóa phòng chiếu này vì đã có suất chiếu",
                        Data = null
                    };
                }

                var seats = await _context.Seats.Where(x => x.CinemaId == id).ToListAsync();

                foreach (var seat in seats)
                {
                    var lstTicket = await _context.Tickets.Where(x => x.Seat.Id == seat.Id).ToListAsync();
                    if (lstTicket.Count > 0)
                    {
                        return new ResponseObject<Cinema>
                        {
                            Status = StatusCodes.Status400BadRequest,
                            Message = "Không thể xóa phòng chiếu này vì đã có vé được đặt",
                            Data = null
                        };
                    }
                }

                _context.Seats.RemoveRange(seats);
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
                if (request.Column < 2 || request.Column > 30)
                {
                    return new ResponseObject<CinemaDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Số cột nằm trong khoảng 2 -> 30"
                    };
                }
                if (request.Row < 2 || request.Row > 26)
                {
                    return new ResponseObject<CinemaDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Số hàng nằm trong khoảng 2 -> 26"
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

        private string AlphabeticalOrder(int number)
        {
            List<string> Alphabet = new List<string>
            { "A", "B", "C", "D",
              "E", "F", "G", "H",
              "I", "J", "K", "L",
              "M", "N", "O", "P",
              "Q", "R", "S", "T",
              "U", "V", "W", "X",
              "Y", "Z"
            };
            return Alphabet[number];
        }
    }
}