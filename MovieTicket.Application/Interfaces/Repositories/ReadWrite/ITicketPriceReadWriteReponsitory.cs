using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface ITicketPriceReadWriteReponsitory
    {
        Task<ResponseObject<TicketPriceCreateRequest>> Create(TicketPriceCreateRequest request, CancellationToken cancellationToken);

        Task<ResponseObject<TicketPriceUpdateRequest>> Update(TicketPriceUpdateRequest request, CancellationToken cancellationToken);

        Task<ResponseObject<bool>> Delete(Guid id, CancellationToken cancellationToken);
    }
}