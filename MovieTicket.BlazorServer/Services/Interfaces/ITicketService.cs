using MovieTicket.Application.DataTransferObjs.Ticket;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface ITicketService
    {
        Task<List<TicketDto>> GetListTicketByBillIdAsync(Guid billId);
    }
}
