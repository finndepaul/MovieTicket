using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface ITicketPriceReadOnlyRepository
    {
        Task<PageList<TicketPriceDto>> GetListTicketPriceAsync(TicketPriceWithPaginationRequest request, PagingParameters pagingParameters,CancellationToken cancellationToken);

        Task<TicketPriceDto> GetTicketPriceByIdAsync(Guid id);
    }
}