using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.Account.Request
{
    public class ChangePasswordRequest
    {
        public Guid Id { get; set; }
        public string OldPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(16, ErrorMessage = "Password must be between 8 and 32 characters", MinimumLength = 8)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password and Confirm Password must match")]
        public string NewPasswordConFirm { get; set; }
    }
}