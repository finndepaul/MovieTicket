using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public  class Schedule
{
    public Guid? Id { get; set; }

    public Guid? FilmId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? Type { get; set; }

    public int? Status { get; set; }

    public virtual Film? Film { get; set; }
    public virtual ICollection<ShowTime>? ShowTimes { get; set; }
}
