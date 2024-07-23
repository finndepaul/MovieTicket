
using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public class Cinema
{
    public Guid Id { get; set; }

    public Guid? CinemaTypeId { get; set; }

    public Guid? CinemaCenterId { get; set; }

    public string? Name { get; set; }

    public int? Column { get; set; }

    public int? Row { get; set; }

    public int? MaxSeatCapacity { get; set; }

    public string? Description { get; set; }

    public virtual CinemaCenter? CinemaCenter { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public virtual ICollection<ShowTime> ShowTimes { get; set; } = new List<ShowTime>();
    public virtual CinemaType? CinemaType { get; set; } 
}
