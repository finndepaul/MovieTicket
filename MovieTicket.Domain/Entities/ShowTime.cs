using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Domain.Entities;

public  class ShowTime
{
    public Guid Id { get; set; }
    public Guid? FilmId { get; set; }
    public Guid? ScheduleId { get; set; }
    public Guid? CinemaCenterId { get; set; }
    public Guid? CinemaId { get; set; }
    public Guid? ScreenTypeId { get; set; }
    public Guid? TranslationTypeId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
	public DateTime? ShowtimeDate { get; set; } // Ngày chiếu dự trên lịch chiếu
	public string? Desciption { get; set; }
    public ShowtimeStatus? Status { get; set; }

    public virtual Cinema? Cinema { get; set; }
    public virtual CinemaCenter? CinemaCenter { get; set; }
    public virtual Film? Film { get; set; }
    public virtual Schedule? Schedule { get; set; }
    public virtual ScreenType? ScreenType { get; set; }
    public virtual TranslationType? TranslationType { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
