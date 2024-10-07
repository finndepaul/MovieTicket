using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.TicketPrice
{
    public class TicketPriceDto
    {
        public Guid Id { get; set; }
        public Guid? SeatTypeId { get; set; }

        public Guid? ScreenTypeId { get; set; }

        public Guid? ScreeningDayId { get; set; }

        public Guid? CinemaTypeId { get; set; }
        public string? NameSeat { get; set; } //Seat tên ghế
        public string? NameCinema { get; set; }//Cinema
        public string? Type { get; set; } //Screen
        public string? Day { get; set; }//ScreeningDay
        public decimal? Price { get; set; }

        public TicketPriceStatus Status { get; set; }
    }
}