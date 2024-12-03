using MovieTicket.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.Account.Request
{
    public class AccountUpdateRequest
    {
        public Guid Id { get; set; }
        public string? Avatar { get; set; }
        public string? Username { get; set; }
        [Required(ErrorMessage = "Họ và tên là bắt buộc.")]
        public string? Name { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Địa chỉ email sai định dạng !!!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Địa chỉ phone sai định dạng !!!")]
        public string? Phone { get; set; }
        [Required]
        public AccountRole? Role { get; set; }
        [Required]
        public AccountStatus? Status { get; set; }
        public Guid? CinemaCenterId { get; set; }
    }
}