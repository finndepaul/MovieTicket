using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.Cinema.Request
{
    public class CinemaUpdateRequest
    {
        public Guid Id { get; set; }
        [Required]
        public Guid CinemaCenterId { get; set; }

        [Required(ErrorMessage = "Tên không được để trống")]
        [Length(5, 100, ErrorMessage = "Tên phải có ít nhất 5 ký tự và tối đa 100 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Chưa chọn loại phòng chiếu")]
        public Guid CinemaTypeId { get; set; }

        [Required]
        [Range(2, 30, ErrorMessage = "Số cột nằm trong khoảng 2 -> 30")]
        public int Column { get; set; }

        [Required]
        [Range(2, 26, ErrorMessage = "Số hàng nằm trong khoảng 2 -> 26")]
        public int Row { get; set; }

        [Required(ErrorMessage = "Chưa nhập mô tả")]
        [Length(1, 255, ErrorMessage = "Mô tả phải có ít nhất 1 ký tự và tối đa 255 ký tự")]
        public string Description { get; set; }
    }
}