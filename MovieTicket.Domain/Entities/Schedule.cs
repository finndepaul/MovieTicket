using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public  class Schedule
{
    public Guid? Id { get; set; }

    public Guid? FilmId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public ScheduleType? Type { get; set; }

    public ScheduleStatus? Status { get; set; }
    //public bool? ActivationStatus { get; set; }

    public virtual Film? Film { get; set; }
    public virtual ICollection<ShowTime>? ShowTimes { get; set; }
}
