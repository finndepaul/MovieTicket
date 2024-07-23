using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public  class TranslationType
{
    public Guid? Id { get; set; }

    public string? Type { get; set; }
    public virtual ShowTime? ShowTime { get; set; }
    public virtual ICollection<FilmTranslationType>? FilmTranslationTypes { get; set; }

}
