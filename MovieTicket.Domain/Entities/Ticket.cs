using MovieTicket.Domain.Enums;

namespace MovieTicket.Domain.Entities;

public class Ticket
{
	public Guid Id { get; set; }

	public Guid? BillId { get; set; }

	public Guid? ShowTimeId { get; set; }

	public Guid? CinemaCenterId { get; set; }

	public Guid? SeatId { get; set; }

	public Guid? TicketPriceId { get; set; }

	public string? Qrcode { get; set; }

	public string? Description { get; set; }

	public TicketStatus? Status { get; set; }

	public virtual Bill? Bill { get; set; }
	public virtual TicketPrice? TicketPrice { get; set; }

	public virtual CinemaCenter? CinemaCenter { get; set; }

	public virtual Seat? Seat { get; set; }

	public virtual ShowTime? ShowTime { get; set; }
}