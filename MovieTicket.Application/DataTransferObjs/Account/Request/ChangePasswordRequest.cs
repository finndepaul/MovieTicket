using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.Account.Request
{
    public class ChangePasswordRequest
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Mật khẩu cũ là bắt buộc")]
        public string OldPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(16, ErrorMessage = "Mật khẩu phải từ 8 đến 32 ký tự", MinimumLength = 8)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu và Xác nhận mật khẩu phải trùng nhau")]
        public string NewPasswordConFirm { get; set; }
    }
}