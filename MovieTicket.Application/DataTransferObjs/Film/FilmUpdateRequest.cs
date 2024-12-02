using MovieTicket.Application.ValueObjs;
using MovieTicket.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.Film
{
    
    public class FilmUpdateRequest
    {
        [Required(ErrorMessage = "Tên là bắt buộc")]
        [StringLength(255, ErrorMessage = "Tên phải dài từ 1 đến 255 ký tự.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Tên tiếng anh là bắt buộc")]
        [StringLength(255, ErrorMessage = "Tên tiếng Anh phải dài từ 1 đến 255 ký tự.")]
        public string? EnglishName { get; set; }

        [Url(ErrorMessage = "Trailer phải là một URL hợp lệ.")]
        public string? Trailer { get; set; }

        [StringLength(1000, ErrorMessage = "Mô tả không được quá 1000 ký tự.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Thể loại là bắt buộc")]
        public string? Gerne { get; set; }

        [StringLength(255, ErrorMessage = "Đạo diễn không được vượt quá 255 ký tự.")]
        public string? Director { get; set; }

        [StringLength(1000, ErrorMessage = "Danh sách diễn viên không được vượt quá 1000 ký tự.")]
        public string? Cast { get; set; }

        [Range(3, 100, ErrorMessage = "Độ tuổi phải nằm trong khoảng từ 3 đến 100.")]
        public int? Rating { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày bắt đầu là bắt buộc")]

        [CustomValidation(typeof(FilmUpdateRequest), nameof(ValidateStartDate))]
        public DateTime? StartDate { get; set; }

        [Range(1800, 2100, ErrorMessage = "Năm phát hành phải nằm trong khoảng từ 1800 đến 2100.")]
        public int? ReleaseYear { get; set; }
        [Range(1, 500, ErrorMessage = "Thời lượng phim phải từ 1 đến 500 phút.")]
        public int? RunningTime { get; set; }

        [StringLength(255, ErrorMessage = "Quốc gia không được vượt quá 255 ký tự.")]
        public string? Nation { get; set; }

        public string? Poster { get; set; }

        [StringLength(255, ErrorMessage = "Ngôn ngữ không được vượt quá 255 ký tự.")]
        public string? Language { get; set; }
        public static ValidationResult? ValidateStartDate(DateTime? startDate, ValidationContext context)
        {
            if (startDate.HasValue && startDate.Value < DateTime.Now.Date)
            {
                return new ValidationResult("Ngày bắt đầu phải ở hiện tại hoặc tương lai.");
            }

            return ValidationResult.Success;
        }
        [Required(ErrorMessage = "Phải chọn hình thức chiếu")]
        public List<Guid> ScreenTypeIds { get; set; } = new List<Guid>();
        [Required(ErrorMessage = "Phải chọn hình thức dịch")]
        public List<Guid> TranslationTypeIds { get; set; } = new List<Guid>();

    }
}