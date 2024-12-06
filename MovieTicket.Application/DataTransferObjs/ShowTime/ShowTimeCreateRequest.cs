using MovieTicket.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.ShowTime
{
    public class ShowTimeCreateRequest
    {
		[Required(ErrorMessage = "Phim không được để trống")]
		public Guid? FilmId { get; set; }

		[Required(ErrorMessage = "Lịch chiếu không được để trống")]
		public Guid? ScheduleId { get; set; }

		[Required(ErrorMessage = "Rạp chiếu không được để trống")]
		public Guid? CinemaCenterId { get; set; }

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

		[Required(ErrorMessage = "Ngày chiếu không được để trống")]
		public DateTime? ShowtimeDate { get; set; } // Ngày chiếu dự trên lịch chiếu

		[Required(ErrorMessage = "Mô tả không được để trống")]
		public string? Desciption { get; set; }
		public ShowtimeStatus? Status { get; set; }
		public DateTime? ShowtimeEndDate { get; set; }
	}
}