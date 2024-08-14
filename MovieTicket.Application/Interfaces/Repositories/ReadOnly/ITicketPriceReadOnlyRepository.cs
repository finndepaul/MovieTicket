using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
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
        Task<ResponseObject<TicketPriceDto>> GetByIdAsync(Guid id);
    }
}
