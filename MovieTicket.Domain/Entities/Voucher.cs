using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public  class Voucher
{
    public Guid Id { get; set; }

    public virtual ICollection<Bill>? Bills { get; set; }
    public virtual ICollection<VoucherDetail>? VoucherDetails { get; set; }

}
