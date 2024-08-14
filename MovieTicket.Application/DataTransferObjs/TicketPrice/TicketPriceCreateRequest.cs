using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.TicketPrice
{
    public class TicketPriceCreateRequest
    {
        public Guid? SeatTypeId { get; set; }

        public Guid? ScreenTypeId { get; set; }

        public Guid? ScreeningDayId { get; set; }

        public Guid? CinemaTypeId { get; set; }

        [Range(0,int.MaxValue,ErrorMessage = "Must be positive")]
        public decimal? Price { get; set; }
    }
}
