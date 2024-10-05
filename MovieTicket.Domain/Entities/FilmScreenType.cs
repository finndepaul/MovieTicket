namespace MovieTicket.Domain.Entities;

public class FilmScreenType
{
    public Guid FilmId { get; set; }
    public Guid ScreenTypeId { get; set; }
    public virtual ScreenType? ScreenType { get; set; }
    public virtual Film? Film { get; set; }
}