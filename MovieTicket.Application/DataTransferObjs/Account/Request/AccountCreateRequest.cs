using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MovieTicket.Application.DataTransferObjs.Account.Request
{
    public class AccountCreateRequest
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_-]+$", ErrorMessage = "Tên người dùng không được chứa khoảng trắng hoặc ký tự đặc biệt và không được có dấu phụ.")]
        public string? Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Mật khẩu phải chứa ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường và số.")]
        public string? Password { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Địa chỉ phone sai định dạng !!!")]
        public string? Phone { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Địa chỉ email sai định dạng !!!")]
        public string? Email { get; set; }
    }
}