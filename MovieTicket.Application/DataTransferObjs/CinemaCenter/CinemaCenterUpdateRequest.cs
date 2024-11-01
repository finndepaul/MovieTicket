using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.CinemaCenter
{
    public class CinemaCenterUpdateRequest
    {
        [Required(ErrorMessage = "Tên rạp chiếu là bắt buộc")]
        [MinLength(6, ErrorMessage = "Tên rạp chiếu phải có ít nhất 6 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        [MinLength(10, ErrorMessage = "Địa chỉ phải có ít nhất 10 ký tự")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Địa chỉ bản đồ là bắt buộc")]
        [MinLength(15, ErrorMessage = "Địa chỉ map phải có ít nhất 15 ký tự")]
        public string AddressMap { get; set; }
    }
}