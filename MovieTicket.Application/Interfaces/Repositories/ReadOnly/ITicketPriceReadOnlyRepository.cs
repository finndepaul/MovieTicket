using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.ValueObjs.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface ITicketPriceReadOnlyRepository
    {
        Task<IQueryable<TicketPriceDto>> GetListAsync(TicketPriceWithPaginationRequest request,CancellationToken cancellationToken);
        Task<TicketPriceDto> GetByIdAsync(Guid id);
    }
}
