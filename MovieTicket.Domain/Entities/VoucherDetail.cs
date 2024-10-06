namespace MovieTicket.Domain.Entities;

public class VoucherDetail
{
    public Guid Id { get; set; }

    public Guid? VoucherId { get; set; }

    public virtual Voucher? Voucher { get; set; }
}