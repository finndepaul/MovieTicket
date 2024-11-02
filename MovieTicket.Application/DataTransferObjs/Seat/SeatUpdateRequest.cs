using MovieTicket.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.Seat
{
    public class SeatUpdateRequest
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Chưa chọn loại ghế")]
        public string SeatTypeId { get; set; }

        [Required(ErrorMessage = "Chưa chọn trạng thái ghế")]
        public SeatStatus Status { get; set; }

        public SeatSelection Selection { get; set; }
    }
}