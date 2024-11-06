namespace MovieTicket.Domain.Entities;

public class Cinema
{
    public virtual CinemaCenter CinemaCenter { get; set; }
    public Guid CinemaCenterId { get; set; }
    public virtual CinemaType CinemaType { get; set; }
    public Guid CinemaTypeId { get; set; }
    public int Column { get; set; }
    public DateTime CreateTime { get; set; }
    public string Description { get; set; }
    public Guid Id { get; set; }
    public int MaxSeatCapacity { get; set; }
    public string Name { get; set; }
    public int Row { get; set; }
    public DateTime UpdateTime { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public virtual ICollection<ShowTime> ShowTimes { get; set; } = new List<ShowTime>();
}