using MovieTicket.Domain.Enums;

namespace MovieTicket.Domain.Entities;

public class Seat
{
    public Guid Id { get; set; }

    public Guid? SeatTypeId { get; set; }

    public Guid? CinemaId { get; set; }

    public int? Position { get; set; }

    public SeatStatus? Status { get; set; }

    public virtual Cinema? Cinema { get; set; }

    public virtual SeatType? SeatType { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public virtual ICollection<BillSeat> BillSeats { get; set; } = new List<BillSeat>();
}