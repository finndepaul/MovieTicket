using MovieTicket.Application.ValueObjs.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.TicketPrice
{
    public class TicketPriceWithPaginationRequest
    {
        public Guid? SeatTypeId { get; set; }

        public Guid? ScreenTypeId { get; set; }

        public Guid? ScreeningDayId { get; set; }

        public Guid? CinemaTypeId { get; set; }
    }
}
