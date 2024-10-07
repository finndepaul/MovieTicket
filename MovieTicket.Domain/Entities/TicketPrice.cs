using MovieTicket.Domain.Entitis;
using MovieTicket.Domain.Enums;

namespace MovieTicket.Domain.Entities;

public class TicketPrice
{
    public Guid Id { get; set; }

    public Guid? SeatTypeId { get; set; }

    public Guid? ScreenTypeId { get; set; }

    public Guid? ScreeningDayId { get; set; }

    public Guid? CinemaTypeId { get; set; }

    public decimal? Price { get; set; }
    public TicketPriceStatus Status { get; set; }

    public virtual Ticket? Ticket { get; set; }
    public virtual ScreeningDay? ScreeningDay { get; set; }
    public virtual ScreenType? ScreenType { get; set; }
    public virtual CinemaType? CinemaTypes { get; set; }
    public virtual SeatType? SeatType { get; set; }
}