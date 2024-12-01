using MovieTicket.Application.DataTransferObjs.Ticket;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface ITicketReadOnlyRepository
    {
        Task<IQueryable<TicketDto>> GetListTicketByBillId(Guid billId, CancellationToken cancellationToken);
        Task<IQueryable<TicketDto>> GetListTicketByShowTimeId(Guid showTimeId, CancellationToken cancellationToken);
    }

}
