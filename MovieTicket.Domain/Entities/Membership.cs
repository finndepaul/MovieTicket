using MovieTicket.Domain.Enums;

namespace MovieTicket.Domain.Entities;

public class Membership
{
    public Guid Id { get; set; }

    //public Guid? AccountId { get; set; }

    public int? Point { get; set; }

    public MembershipStatus? Status { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual Account? Account { get; set; }
}