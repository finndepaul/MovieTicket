using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.Auth.Requests
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Chưa nhập tên tài khoản")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}