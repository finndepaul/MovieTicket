using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public class ConfirmedEmail
{
    public Guid Id { get; set; }
    public Guid? AccountId { get; set; }
    public string ConfirmCode { get; set; }
    public DateTime ExpiryTime { get; set; }
    public bool IsConfirmed { get; set; } = false;
    public virtual Account? Account { get; set; }
}
