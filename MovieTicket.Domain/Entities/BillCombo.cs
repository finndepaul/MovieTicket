﻿namespace MovieTicket.Domain.Entities;

public class BillCombo
{
    public Guid? BillId { get; set; }
    public Guid? ComboId { get; set; }
    public int Quantity { get; set; }

    public virtual Bill? Bill { get; set; }
    public virtual Combo? Combo { get; set; }
}