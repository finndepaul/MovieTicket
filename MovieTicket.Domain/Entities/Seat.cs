using MovieTicket.Domain.Enums;

namespace MovieTicket.Domain.Entities;

public class Seat
{
    public virtual ICollection<BillSeat> BillSeats { get; set; } = new List<BillSeat>();
    public virtual Cinema? Cinema { get; set; }
    public Guid? CinemaId { get; set; }
    public int? Column { get; set; }
    public Guid Id { get; set; }
    public string? Position { get; set; }
    public int? Row { get; set; }
    public virtual SeatType? SeatType { get; set; }
    public Guid? SeatTypeId { get; set; }
    public SeatSelection? Selection { get; set; }
    public SeatStatus? Status { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}