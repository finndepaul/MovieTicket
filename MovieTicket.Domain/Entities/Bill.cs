using MovieTicket.Domain.Enums;

namespace MovieTicket.Domain.Entities;

public class Bill
{
    public Guid Id { get; set; }

    public Guid? MembershipId { get; set; }

    public Guid? VoucherId { get; set; }

    public decimal? TotalMoney { get; set; }

    public DateTime? CreateTime { get; set; }

    public string? BarCode { get; set; }

    public BillStatus? Status { get; set; }
    public bool? ActivationStatus { get; set; }

    public virtual Membership? Membership { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public virtual Voucher? Voucher { get; set; }
    public virtual ICollection<BillCombo> BillCombos { get; set; } = new List<BillCombo>();
    public virtual ICollection<BillSeat> BillSeats { get; set; } = new List<BillSeat>();
}