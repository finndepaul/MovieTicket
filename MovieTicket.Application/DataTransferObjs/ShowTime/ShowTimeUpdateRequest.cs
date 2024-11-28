using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.ShowTime
{
    public class ShowTimeUpdateRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Phim không được để trống")]
		public Guid? FilmId { get; set; }

		[Required(ErrorMessage = "Lịch chiếu không được để trống")]
		public Guid? ScheduleId { get; set; }

		[Required(ErrorMessage = "Phòng chiếu không được để trống")]
		public Guid? CinemaId { get; set; }

		[Required(ErrorMessage = "Hình thức chiếu không được để trống")]
		public Guid? ScreenTypeId { get; set; }

		[Required(ErrorMessage = "Hình thức dịch không được để trống")]
		public Guid? TranslationTypeId { get; set; }

		[Required(ErrorMessage = "Thời gian bắt đầu không được để trống")]
		public DateTime? StartTime { get; set; }

		[Required(ErrorMessage = "Thời gian kết thúc không được để trống")]
		public DateTime? EndTime { get; set; }
		public DateTime? ShowtimeDate { get; set; } // Ngày chiếu dự trên lịch chiếu
		public ShowtimeStatus? Status { get; set; }
	}
}
