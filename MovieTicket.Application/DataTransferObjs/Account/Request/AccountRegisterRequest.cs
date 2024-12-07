using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.Account.Request
{
    public class AccountRegisterRequest
    {
        [Required(ErrorMessage = "Chưa nhập tên tài khoản")]
        [StringLength(16, ErrorMessage = "Tên tài khoản phải từ 5 đến 16 kí tự", MinimumLength = 5)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "Mật khẩu phải từ 8 đến 32 kí tự", MinimumLength = 8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Chưa xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Nhập lại mật khẩu chưa chính xác")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Chưa nhập tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Chưa nhập số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(0)\d{9}$", ErrorMessage = "Số điện thoại chưa đúng")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Chưa nhập Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}