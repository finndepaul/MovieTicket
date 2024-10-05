using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.Account.Request
{
    public class AccountUpdateRequest
    {
        public Guid Id { get; set; }
        public string? Avatar { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public AccountRole? Role { get; set; }
        public AccountStatus? Status { get; set; }
    }
}