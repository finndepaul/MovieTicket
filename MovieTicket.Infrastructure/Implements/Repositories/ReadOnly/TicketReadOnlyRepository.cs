using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Ticket;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class TicketReadOnlyRepository : ITicketReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _db;

        public TicketReadOnlyRepository(MovieTicketReadOnlyDbContext db)
        {
            _db = db;
        }
        public async Task<IQueryable<TicketDto>> GetListTicketByBillId(Guid billId, CancellationToken cancellationToken)
        {
            var query = await _db.Tickets.Where(x => x.BillId == billId)
                .Select(x => new TicketDto
                {
                    Id = x.Id,
                    BillId = x.BillId,
                    ShowTimeId = x.ShowTimeId,
                    SeatId = x.SeatId,
                    TicketPriceId = x.TicketPriceId,
                    Qrcode = x.Qrcode,
                    Description = x.Description,
                    Status = x.Status
                }).AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }
        
        public async Task<IQueryable<TicketDto>> GetListTicketByShowTimeId(Guid showTimeId, CancellationToken cancellationToken)
        {
            var query = await _db.Tickets.Where(x => x.ShowTimeId == showTimeId)
                .Select(x => new TicketDto
                {
                    Id = x.Id,
                    BillId = x.BillId,
                    ShowTimeId = x.ShowTimeId,
                    SeatId = x.SeatId,
                    TicketPriceId = x.TicketPriceId,
                    Qrcode = x.Qrcode,
                    Description = x.Description,
                    Status = x.Status
                }).AsNoTracking().ToListAsync();
            if (query == null)
            {
                return null;
            }
            return query.AsQueryable();
        }
    }
}
