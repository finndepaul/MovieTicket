using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.TicketPrice
{
    public class TicketPriceWithPaginationRequest
    {
        public Guid? SeatTypeId { get; set; }

        public Guid? ScreenTypeId { get; set; }

        public Guid? ScreeningDayId { get; set; }

        public Guid? CinemaTypeId { get; set; }
        public TicketPriceStatus? Status { get; set; }
    }
}