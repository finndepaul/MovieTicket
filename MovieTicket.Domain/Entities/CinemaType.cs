﻿using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public class CinemaType
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public virtual Cinema? Cinema { get; set; }
    public virtual ICollection<TicketPrice>? TicketPrices { get; set; }
}
