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

		public async Task<TicketPriceDto> GetTicketPriceByIdAsync(Guid id)
		{
			var query = await _context.TicketPrices
				.Join(_context.ScreeningDays,
					  tp => tp.ScreeningDayId,
					  sd => sd.Id,
					  (tp, sd) => new { tp, sd })
				.Join(_context.SeatTypes,
					  x => x.tp.SeatTypeId,
					  set => set.Id,
					  (x, set) => new { x.tp, x.sd, set })
				.Join(_context.ScreenTypes,
					  x => x.tp.ScreenTypeId,
					  sct => sct.Id,
					  (x, sct) => new { x.tp, x.sd, x.set, sct })
				.Join(_context.CinemaTypes,
					  x => x.tp.CinemaTypeId,
					  ct => ct.Id,
					  (x, ct) => new { x.tp, x.sd, x.set, x.sct, ct })
				.Select(x => new TicketPriceDto
				{
					Id = x.tp.Id,
					CinemaTypeName = x.ct.Name,
					SeatName = x.set.Name,
					Type = x.sct.Type,
					Day = x.sd.Day,
					Price = x.tp.Price,
					Status = x.tp.Status
				}).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
			if (query == null)
			{
				throw new InvalidOperationException($"No ticket price found for ID {id}.");
			}
			return query;

		}

		public async Task<IQueryable<TicketPriceDto>> GetListTicketPriceAsync(TicketPriceWithPaginationRequest request, CancellationToken cancellationToken)
		{
			var query = _context.TicketPrices
				.Join(_context.ScreeningDays,
					  tp => tp.ScreeningDayId,
					  sd => sd.Id,
					  (tp, sd) => new { tp, sd })
				.Join(_context.SeatTypes,
					  x => x.tp.SeatTypeId,
					  set => set.Id,
					  (x, set) => new { x.tp, x.sd, set })
				.Join(_context.ScreenTypes,
					  x => x.tp.ScreenTypeId,
					  sct => sct.Id,
					  (x, sct) => new { x.tp, x.sd, x.set, sct })
				.Join(_context.CinemaTypes,
					  x => x.tp.CinemaTypeId,
					  ct => ct.Id,
					  (x, ct) => new { x.tp, x.sd, x.set, x.sct, ct });
			if (request.ScreeningDayId.HasValue)
			{
				query = query.Where(x => x.sd.Id == request.ScreeningDayId);
			}
			if (request.SeatTypeId.HasValue)
			{
				query = query.Where(x => x.set.Id == request.SeatTypeId);
			}
			if (request.ScreenTypeId.HasValue)
			{
				query = query.Where(x => x.sct.Id == request.ScreenTypeId);
			}
			if (request.CinemaTypeId.HasValue)
			{
				query = query.Where(x => x.ct.Id == request.CinemaTypeId);
			}
			var result = await query.Select(x => new TicketPriceDto
			{
				Id = x.tp.Id,
				CinemaTypeName = x.ct.Name,
				SeatName = x.set.Name,
				Type = x.sct.Type,
				Day = x.sd.Day,
				Price = x.tp.Price,
				Status = x.tp.Status
			}).OrderBy(x => x.Status).AsNoTracking().ToListAsync(cancellationToken);
			return result.AsQueryable();
		}
	}
}