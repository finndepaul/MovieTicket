namespace MovieTicket.Domain.Entities;

public class PromotionDetail
{
    public Guid Id { get; set; }

    public Guid? PromotionId { get; set; }

    public virtual Promotion? Promotion { get; set; }
}