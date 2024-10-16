using MovieTicket.Domain.Entities;

namespace MovieTicket.Domain.Entitis;

public class ScreeningDay
{
    public Guid Id { get; set; }

    public string Day { get; set; }

    public virtual ICollection<TicketPrice>? TicketPrices { get; set; }
}