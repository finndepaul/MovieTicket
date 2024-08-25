using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.ShowTime
{
    public class ShowTimeCreateRequest
    {
        [Required]
        public Guid? FilmId { get; set; }
        [Required]
        public Guid? ScheduleId { get; set; }
        [Required]
        public Guid? CinemaCenterId { get; set; }
        [Required]
        public Guid? CinemaId { get; set; }
        [Required]
        public Guid? ScreenTypeId { get; set; }
        [Required]
        public Guid? TranslationTypeId { get; set; }
        [Required]
        public DateTime? StartTime { get; set; }
        [Required]
        public DateTime? EndTime { get; set; }
		[Required]
		public DateTime? ShowtimeDate { get; set; } // Ngày chiếu dự trên lịch chiếu
		[Required]
        public string? Desciption { get; set; }
        [Required]
        public ShowtimeStatus? Status { get; set; }
    }
}
