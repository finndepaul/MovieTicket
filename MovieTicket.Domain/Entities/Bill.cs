using MovieTicket.Domain.Enums;

namespace MovieTicket.Domain.Entities;

public class Bill
{
    public Guid Id { get; set; }
    public Guid? MembershipId { get; set; }
    public Guid? CouponId { get; set; }
    public decimal? TotalMoney { get; set; }
    public decimal? AfterDiscount { get; set; }
    public DateTime CreateTime { get; set; }
    public string? BarCode { get; set; }
    public BillStatus? Status { get; set; }
    public bool? ActivationStatus { get; set; } //Vé đã được kích hoạt hay chưa

    public virtual Membership? Membership { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public virtual Coupon? Coupon { get; set; }
    public virtual ICollection<BillCombo> BillCombos { get; set; } = new List<BillCombo>();
}