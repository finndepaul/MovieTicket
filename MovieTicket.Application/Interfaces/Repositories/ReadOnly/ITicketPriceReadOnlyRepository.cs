using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface ITicketPriceReadOnlyRepository
    {
        Task<IQueryable<TicketPriceDto>> GetListTicketPriceAsync(TicketPriceWithPaginationRequest request, CancellationToken cancellationToken);

        Task<TicketPriceDto> GetTicketPriceByIdAsync(Guid id);
    }
}