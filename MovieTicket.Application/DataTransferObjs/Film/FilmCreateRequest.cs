using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs.Film
{
    public class FilmCreateRequest
    {
        [Required(ErrorMessage = "Tên là bắt buộc")]
        [StringLength(255, ErrorMessage = "Tên phải dài từ 1 đến 255 ký tự.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Tên tiếng anh là bắt buộc")]
        [StringLength(255, ErrorMessage = "Tên tiếng Anh phải dài từ 1 đến 255 ký tự.")]
        public string? EnglishName { get; set; }

        [Required(ErrorMessage = "Trailer là bắt buộc")]
        [Url(ErrorMessage = "Trailer phải là một URL hợp lệ.")]
        public string? Trailer { get; set; }

        [Required(ErrorMessage = "Mô tả là bắt buộc")]
        [StringLength(1000, ErrorMessage = "Mô tả không được quá 1000 ký tự.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Thể loại là bắt buộc")]
        public string? Gerne { get; set; }
        [Required(ErrorMessage = "Đạo diễn là bắt buộc")]
        [StringLength(255, ErrorMessage = "Đạo diễn không được vượt quá 255 ký tự.")]
        public string? Director { get; set; }

        [Required(ErrorMessage = "Diễn viên là bắt buộc")]
        [StringLength(1000, ErrorMessage = "Danh sách diễn viên không được vượt quá 1000 ký tự.")]
        public string? Cast { get; set; }

        [Required(ErrorMessage = "Độ tuổi là bắt buộc")]
        [Range(3, 100, ErrorMessage = "Độ tuổi phải nằm trong khoảng từ 3 đến 100.")]
        public int? Rating { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày bắt đầu là bắt buộc")]
        [CustomValidation(typeof(FilmCreateRequest), nameof(ValidateStartDate))]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Năm phát hành là bắt buộc")]
        [CustomValidation(typeof(FilmCreateRequest), nameof(ValidateReleaseYears))]
        public int? ReleaseYear { get; set; }

        [Required(ErrorMessage = "Thời lượng phim là bắt buộc")]
        [Range(1, 500, ErrorMessage = "Thời lượng phim phải từ 1 đến 500 phút.")]
        public int? RunningTime { get; set; }

        [Required(ErrorMessage = "Quốc gia là bắt buộc")]
        [StringLength(255, ErrorMessage = "Quốc gia không được vượt quá 255 ký tự.")]
        public string? Nation { get; set; }

        [Required(ErrorMessage = "Ảnh phim là bắt buộc")]
        public string? Poster { get; set; }

        [Required(ErrorMessage = "Ngôn ngữ là bắt buộc")]
        [StringLength(255, ErrorMessage = "Ngôn ngữ không được vượt quá 255 ký tự.")]
        public string? Language { get; set; }

        [Required(ErrorMessage = "Phải chọn hình thức chiếu")]
        public List<Guid> ScreenTypeIds { get; set; } = new List<Guid>();
        [Required(ErrorMessage = "Phải chọn hình thức dịch")]
        public List<Guid> TranslationTypeIds { get; set; } = new List<Guid>();

        public static ValidationResult? ValidateStartDate(DateTime? startDate, ValidationContext context)
        {
            if (startDate.HasValue && startDate.Value < DateTime.Now.Date)
            {
                return new ValidationResult("Ngày bắt đầu phải ở hiện tại hoặc tương lai.");
            }

            return ValidationResult.Success;
        }

        public static ValidationResult? ValidateReleaseYears(int? releaseYear, ValidationContext context)
        {
            if (releaseYear.HasValue)
            {
                int currentYear = DateTime.Now.Year;
                if (releaseYear < 1900 || releaseYear > currentYear)
                {
                    return new ValidationResult($"Năm phát hành phải nằm trong khoảng từ 1900 đến {currentYear}.");
                }
            }
            return ValidationResult.Success;
        }
    }
}