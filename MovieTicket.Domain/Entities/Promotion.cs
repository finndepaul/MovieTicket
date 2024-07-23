using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public  class Promotion
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<PromotionDetail>? PromotionDetails { get; set; }
}
