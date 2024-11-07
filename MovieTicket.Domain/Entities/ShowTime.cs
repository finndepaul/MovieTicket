using MovieTicket.Domain.Enums;

namespace MovieTicket.Domain.Entities;

public class ShowTime
{
    public Guid Id { get; set; }
    public Guid? ScheduleId { get; set; }
    public Guid? CinemaId { get; set; }
    public Guid? ScreenTypeId { get; set; }
    public Guid? TranslationTypeId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public DateTime? ShowtimeDate { get; set; }
    public string? Desciption { get; set; }
    public ShowtimeStatus? Status { get; set; }

    public virtual Cinema? Cinema { get; set; }
    public virtual Schedule? Schedule { get; set; }
    public virtual ScreenType? ScreenType { get; set; }
    public virtual TranslationType? TranslationType { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}