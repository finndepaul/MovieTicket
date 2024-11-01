using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.ShowTime
{
    public class ShowTimeDto
    {
        public Guid Id { get; set; }
        public Guid FilmId { get; set; } // Id phim
        public string FilmName { get; set; } // Tên phim
        public DateTime? StartDate { get; set; } // Ngày bắt đầu
        public DateTime? EndDate { get; set; } // Ngày kết thúc
        public Guid CinemaCenterId { get; set; } // Id rạp chiếu
        public string CinemaCenterName { get; set; } // Tên rạp chiếu
        public Guid CinemaId { get; set; } // Id phòng chiếu
        public string CinemaName { get; set; } // Tên phòng chiếu
        public string ScreenTypeName { get; set; } // Tên loại màn hình
        public string TranslationTypeName { get; set; } // Tên loại phụ đề
        public DateTime? StartTime { get; set; } // Thời gian bắt đầu
        public DateTime? EndTime { get; set; } // Thời gian kết thúc
        public DateTime? ShowtimeDate { get; set; } // Ngày chiếu dự trên lịch chiếu
        public string? Desciption { get; set; }
        public ShowtimeStatus? Status { get; set; }
    }
}