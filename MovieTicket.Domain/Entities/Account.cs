using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public class Account
{
    public Guid Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public AccountRole? Role { get; set; }

    public string? Avatar { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public AccountStatus? Status { get; set; }

    public DateTime? CreateDate { get; set; }

    public virtual Membership? Membership { get; set; }
    public virtual ICollection<ConfirmedEmail>? ConfirmedEmails { get; set; }
    public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }


}
