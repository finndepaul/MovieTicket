using MovieTicket.Application.DataTransferObjs.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface ITicketReadOnlyRepository
    {
       Task<IQueryable<TicketDto>> GetListTicketByBillId(Guid billId,CancellationToken cancellationToken);
	}
}
