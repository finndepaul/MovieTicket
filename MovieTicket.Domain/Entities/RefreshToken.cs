using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public  class RefreshToken
{
    public Guid Id { get; set; }
    public Guid? AccountId { get; set; }
    public string Token { get; set; }
    public DateTime ExpiryTime { get; set; }
    public virtual Account? Account { get; set; }

}
