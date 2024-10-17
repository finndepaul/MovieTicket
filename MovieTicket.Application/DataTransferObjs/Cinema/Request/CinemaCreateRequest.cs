using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.Cinema.Request
{
    public class CinemaCreateRequest
    {
        [Required(ErrorMessage = "Tên không được để trống")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Chưa chọn loại phòng chiếu")]
        public Guid CinemaTypeId { get; set; }

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