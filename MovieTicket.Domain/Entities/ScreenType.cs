using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public  class ScreenType
{
    public Guid? Id { get; set; }

    public string? Type { get; set; }
    public virtual ShowTime? ShowTime { get; set; }
    public virtual ICollection<TicketPrice>? TicketPrices { get; set; }
    public virtual ICollection<FilmScreenType>? FilmScreenTypes { get; set; }

}
