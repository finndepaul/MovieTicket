using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class TicketPriceReadOnlyReponsitory : ITicketPriceReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _context;
        private readonly IMapper _mapper;

        public TicketPriceReadOnlyReponsitory(MovieTicketReadOnlyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseObject<TicketPriceDto>> GetByIdAsync(Guid id)
        {
            var query = await (from tp in _context.TicketPrices
                               join sd in _context.ScreeningDays on tp.ScreeningDayId equals sd.Id
                               join set in _context.SeatTypes on tp.SeatTypeId equals set.Id
                               join sct in _context.ScreenTypes on tp.ScreenTypeId equals sct.Id
                               join ct in _context.CinemaTypes on tp.CinemaTypeId equals ct.Id
                               select new TicketPriceDto
                               {
                                   Id = tp.Id,
                                   SeatTypeId = tp.SeatTypeId,
                                   ScreeningDayId = tp.ScreeningDayId,
                                   CinemaTypeId = tp.CinemaTypeId,
                                   ScreenTypeId = tp.ScreenTypeId,
                                   Price = tp.Price,
                                   Day = sd.Day,
                                   NameCinema = ct.Name,
                                   NameSeat = set.Name,
                                   Type = sct.Type,
                                   Status = tp.Status
                               }).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (query == null)
            {
                return new ResponseObject<TicketPriceDto>()
                {
                    Data = null,
                    Message = "Get ticket price fail",
                    Status = StatusCodes.Status404NotFound
                };
            }
            return new ResponseObject<TicketPriceDto>()
            {
                Data = query,
                Message = "Get ticket price success",
                Status = StatusCodes.Status200OK
            };
        }

        public async Task<IQueryable<TicketPriceDto>> GetListAsync(TicketPriceWithPaginationRequest request, CancellationToken cancellationToken)
        {
            var query = (from tp in _context.TicketPrices
                         join sd in _context.ScreeningDays on tp.ScreeningDayId equals sd.Id
                         join set in _context.SeatTypes on tp.SeatTypeId equals set.Id
                         join sct in _context.ScreenTypes on tp.ScreenTypeId equals sct.Id
                         join ct in _context.CinemaTypes on tp.CinemaTypeId equals ct.Id
                         select new TicketPriceDto
                         {
                             Id = tp.Id,
                             SeatTypeId = tp.SeatTypeId,
                             ScreeningDayId = tp.ScreeningDayId,
                             CinemaTypeId = tp.CinemaTypeId,
                             ScreenTypeId = tp.ScreenTypeId,
                             Price = tp.Price,
                             Day = sd.Day,
                             NameCinema = ct.Name,
                             NameSeat = set.Name,
                             Type = sct.Type,
                             Status = tp.Status
                         }).AsNoTracking();

            if (request.ScreeningDayId.HasValue)
            {
                query = query.Where(x => x.ScreeningDayId == request.ScreeningDayId);
            }
            if (request.SeatTypeId.HasValue)
            {
                query = query.Where(x => x.SeatTypeId == request.SeatTypeId);
            }
            if (request.ScreenTypeId.HasValue)
            {
                query = query.Where(x => x.ScreenTypeId == request.ScreenTypeId);
            }
            if (request.CinemaTypeId.HasValue)
            {
                query = query.Where(x => x.CinemaTypeId == request.CinemaTypeId);
            }
            if (request.Status.HasValue)
            {
                query = query.Where(x => x.Status == request.Status);
            }
            return query.AsQueryable();
        }
    }
}