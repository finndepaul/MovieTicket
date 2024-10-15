using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.TicketPrice
{
    public class TicketPriceDto
    {
        public Guid Id { get; set; }
        public string? SeatName { get; set; } //Seat tên ghế
        public string? CinemaTypeName { get; set; }//Cinema
        public string? Type { get; set; } //hinh thuc chieu
        public string? Day { get; set; }//ScreeningDay
        public decimal? Price { get; set; }

        public TicketPriceStatus Status { get; set; }
	}
}