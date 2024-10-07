using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.Account
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string? Avatar { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public AccountRole? Role { get; set; }
        public string? Address { get; set; }
        public AccountStatus? Status { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}