namespace MovieTicket.Domain.Entities;

public class TranslationType
{
    public Guid? Id { get; set; }

    public string? Type { get; set; }
    public virtual ICollection<ShowTime>? ShowTime { get; set; }
    public virtual ICollection<FilmTranslationType>? FilmTranslationTypes { get; set; }
}