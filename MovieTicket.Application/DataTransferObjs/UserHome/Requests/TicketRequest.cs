using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.UserHome.Requests
{
    public class TicketRequest
    {
        public Guid SeatId { get; set; }
        public Guid TicketPriceId { get; set; }
    }
}