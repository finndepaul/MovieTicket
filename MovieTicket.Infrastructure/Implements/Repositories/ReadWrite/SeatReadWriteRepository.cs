using AutoMapper;
using Microsoft.AspNetCore.Http;
using MovieTicket.Application.DataTransferObjs.Seat;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class SeatReadWriteRepository : ISeatReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _dBcontext;
        private readonly IMapper _mapper;

        public SeatReadWriteRepository(MovieTicketReadWriteDbContext dBcontext, IMapper mapper)
        {
            _dBcontext = dBcontext;
            _mapper = mapper;
        }

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
                    Row = PosSplit(request.Position)[0],
                    Column = PosSplit(request.Position)[1],
                    Status = SeatStatus.Available,
                    Selection = SeatSelection.None
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
                        Row = PosSplit(seat.Position)[0],
                        Column = PosSplit(seat.Position)[1],
                        Status = seat.Status.Value,
                        Selection = seat.Selection.Value
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
                seat.SeatTypeId = Guid.Parse(request.SeatTypeId);
                seat.Status = request.Status;
                _dBcontext.Seats.Update(seat);
                await _dBcontext.SaveChangesAsync();
                return new ResponseObject<SeatDTO>
                {
                    Data = new SeatDTO
                    {
                        Id = seat.Id,
                        CinemaName = _dBcontext.Cinemas.Find(seat.CinemaId).Name,
                        SeatTypeName = _dBcontext.SeatTypes.Find(seat.SeatTypeId).Name,
                        Row = PosSplit(seat.Position)[0],
                        Column = PosSplit(seat.Position)[1],
                        Position = seat.Position,
                        Status = seat.Status.Value,
                        Selection = seat.Selection.Value
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

        public async Task<ResponseObject<List<SeatDTO>>> UpdateRangeAsync(List<SeatUpdateRequest> request)
        {
            try
            {
                var seats = new List<Seat>();
                foreach (var req in request)
                {
                    var seat = await _dBcontext.Seats.FindAsync(req.Id);
                    if (seat != null)
                    {
                        seat.SeatTypeId = Guid.Parse(req.SeatTypeId);
                        seat.Status = req.Status;
                        seat.Selection = req.Selection;
                        seats.Add(seat);
                    }
                }
                _dBcontext.Seats.UpdateRange(seats);
                await _dBcontext.SaveChangesAsync();

                var seatDTOs = seats.Select(seat => new SeatDTO
                {
                    Id = seat.Id,
                    CinemaName = _dBcontext.Cinemas.Find(seat.CinemaId).Name,
                    SeatTypeName = _dBcontext.SeatTypes.Find(seat.SeatTypeId).Name,
                    Row = PosSplit(seat.Position)[0],
                    Column = PosSplit(seat.Position)[1],
                    Position = seat.Position,
                    Status = seat.Status.Value,
                    Selection = seat.Selection.Value
                }).ToList();

                return new ResponseObject<List<SeatDTO>>
                {
                    Data = seatDTOs,
                    Status = StatusCodes.Status200OK,
                    Message = "Cập nhật danh sách ghế thành công"
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<List<SeatDTO>>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = e.Message
                };
            }
        }

        private int AlphabeticalOrder(string s) // A -> 1, B -> 2, C -> 3, ...
        {
            //trả về tên hàng dựa theo số thứ tự hàng
            //Hàng: A -> 1, B -> 2, C -> 3, ...
            List<string> Alphabet = new List<string>
            { "A", "B", "C", "D",
              "E", "F", "G", "H",
              "I", "J", "K", "L",
              "M", "N", "O", "P",
              "Q", "R", "S", "T",
              "U", "V", "W", "X",
              "Y", "Z"
            };
            return Alphabet.IndexOf(s) + 1;
        }

        private List<int> PosSplit(string position) // A1 -> [1, 1], B2 -> [2, 2], ...
        {
            //trả về số hang và số cột của ghế từ vị trí ghế
            // A1 -> [1, 1], B2 -> [2, 2], ...
            int col = Int32.Parse(position.Substring(1));
            int row = AlphabeticalOrder(position.ElementAt(0).ToString());
            return new List<int> { row, col };
        }
    }
}