using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public class CinemaCenter
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Cinema> Cinemas { get; set; } = new List<Cinema>();

    public virtual ICollection<ShowTime> ShowTimes { get; set; } = new List<ShowTime>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
