using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using MovieTicket.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class TicketPriceReadOnlyReponsitory : ITicketPriceReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _context;
        private readonly IMapper _mapper;

        public TicketPriceReadOnlyReponsitory(MovieTicketReadOnlyDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseObject<TicketPriceDto>> GetByIdAsync(Guid id)
        {
            var query = await _context.TicketPrices.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
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
                Data = _mapper.Map<TicketPriceDto>(query),
                Message = "Get ticket price success",
                Status = StatusCodes.Status200OK
            };
        }

        public async Task<IQueryable<TicketPriceDto>> GetListAsync(TicketPriceWithPaginationRequest request, CancellationToken cancellationToken)
        {
            var query = _context.TicketPrices.AsNoTracking();
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
            var mapping = await Task.FromResult(_mapper.Map<List<TicketPriceDto>>(query.ToList()));
            return mapping.AsQueryable();
        }
    }
}
