using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.Auth.Requests
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}