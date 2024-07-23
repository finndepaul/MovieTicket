using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public class BillCombo
{
    public Guid? BillId { get; set; }

    public Guid? ComboId { get; set; }

    public virtual Bill? Bill { get; set; }

    public virtual Combo? Combo { get; set; }
}
