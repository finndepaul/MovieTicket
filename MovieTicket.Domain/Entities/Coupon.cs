using System.Security.Cryptography;
using System.Xml.Serialization;

namespace MovieTicket.Domain.Entities;

public class Coupon
{
    public Guid Id { get; set; }
    public string CouponCode { get; set; }
    public decimal AmountValue { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<Bill>? Bills { get; set; }
}