using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MovieTicket.Application.DataTransferObjs.Account.Request
{
    public class AccountCreateRequest
    {
        [Required(ErrorMessage = "Tên tài khoản là bắt buộc.")]
        [RegularExpression(@"^[a-zA-Z0-9_-]+$", ErrorMessage = "Tên người dùng không được chứa khoảng trắng hoặc ký tự đặc biệt và không được có dấu phụ.")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        [RegularExpression(@"^.{8,32}$", ErrorMessage = "Mật khẩu phải từ 8 đến 32 ký tự.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Họ và tên là bắt buộc.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Địa chỉ phone sai định dạng !!!")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Địa chỉ Email là bắt buộc.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Địa chỉ email sai định dạng !!!")]
        public string? Email { get; set; }
    }
}