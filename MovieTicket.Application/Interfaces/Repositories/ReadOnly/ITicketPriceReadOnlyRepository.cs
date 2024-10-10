using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface ITicketPriceReadOnlyRepository
    {
        Task<IQueryable<TicketPriceDto>> GetListAsync(TicketPriceWithPaginationRequest request, CancellationToken cancellationToken);

        Task<ResponseObject<TicketPriceDto>> GetByIdAsync(Guid id);
    }
}