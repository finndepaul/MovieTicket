﻿using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public class Bill
{
    public Guid Id { get; set; }

    public Guid? MembershipId { get; set; }

    public Guid? VoucherId { get; set; }

    public decimal? TotalMoney { get; set; }

    public DateOnly? CreateTime { get; set; }

    public string? BarCode { get; set; }

    public int? Status { get; set; }

    public virtual Membership? Membership { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    public virtual Voucher? Voucher { get; set; }
    public virtual ICollection<BillCombo> BillCombos { get; set; } = new List<BillCombo>();
    public virtual ICollection<BillSeat> BillSeats { get; set; } = new List<BillSeat>();
}
