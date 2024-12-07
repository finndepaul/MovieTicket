using MovieTicket.Application.DataTransferObjs.Ticket;

namespace WebUI.Services.Interfaces
{
    public interface ITicketService
    {
        Task<List<TicketDto>> GetListTicketByBillIdAsync(Guid billId);
        Task<List<TicketDto>> GetListTicketByShowTimeIdAsync(Guid showTimeId);
    }
}
