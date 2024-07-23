using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public  class FilmTranslationType
{
    public Guid FilmId { get; set; }

    public Guid TranslationTypeId { get; set; }

    public virtual TranslationType? TranslationType { get; set; }
    public virtual Film? Film { get; set; }

}
