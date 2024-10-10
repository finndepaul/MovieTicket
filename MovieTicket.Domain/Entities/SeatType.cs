namespace MovieTicket.Domain.Entities;

public class SeatType
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public virtual ICollection<TicketPrice>? TicketPrices { get; set; }
}