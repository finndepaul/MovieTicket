using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.Cinema.Request
{
    public class CinemaCreateRequest
    {
        [Required(ErrorMessage = "Tên không được để trống")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Chưa chọn loại phòng chiếu")]
        public string CinemaTypeId { get; set; } //ValidationMessage không check được Guid, phải convert sang string

        [Required]
        public Guid CinemaCenterId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Số cột phải lớn hơn 0")]
        public int Column { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Số hàng phải lớn hơn 0")]
        public int Row { get; set; }

        [Required(ErrorMessage = "Chưa nhập mô tả")]
        public string Description { get; set; }
    }
}