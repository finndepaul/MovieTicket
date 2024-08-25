using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.TicketPrice
{
    public class TicketPriceUpdateRequest
    {
        public Guid? Id { get; set; }
        public Guid? SeatTypeId { get; set; }

        public Guid? ScreenTypeId { get; set; }

        public Guid? ScreeningDayId { get; set; }

        public Guid? CinemaTypeId { get; set; }

        public decimal? Price { get; set; }
    }
}
