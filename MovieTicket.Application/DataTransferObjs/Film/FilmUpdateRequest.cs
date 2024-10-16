using MovieTicket.Application.ValueObjs;
using MovieTicket.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieTicket.Application.DataTransferObjs.Film
{
    
    public class FilmUpdateRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, ErrorMessage = "Name must be between 1 and 255 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "English name is required.")]
        [StringLength(255, ErrorMessage = "English name must be between 1 and 255 characters.")]
        public string? EnglishName { get; set; }

        [Url(ErrorMessage = "Trailer must be a valid URL.")]
        public string? Trailer { get; set; }

        [StringLength(1000, ErrorMessage = "Description must not exceed 1000 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        public string? Gerne { get; set; }

        [StringLength(255, ErrorMessage = "Director must not exceed 255 characters.")]
        public string? Director { get; set; }

        [StringLength(1000, ErrorMessage = "Cast list must not exceed 1000 characters.")]
        public string? Cast { get; set; }

        [Range(3, 100, ErrorMessage = "Rating must be between 3 and 100.")]
        public int? Rating { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Start date is required.")]
        [CustomValidation(typeof(FilmCreateRequest), nameof(ValidateStartDate))]
        public DateTime? StartDate { get; set; }

        [Range(1800, 2100, ErrorMessage = "Release year must be between 1800 and 2100.")]
        public int? ReleaseYear { get; set; }
        [Range(1, 500, ErrorMessage = "Running time must be between 1 and 500 minutes.")]
        public int? RunningTime { get; set; }
        [EnumDataType(typeof(FilmStatus), ErrorMessage = "Invalid status.")]
        public FilmStatus? Status { get; set; }

        [StringLength(255, ErrorMessage = "Nation must not exceed 255 characters.")]
        public string? Nation { get; set; }

        public string? Poster { get; set; }

        [StringLength(255, ErrorMessage = "Language must not exceed 255 characters.")]
        public string? Language { get; set; }
        public static ValidationResult? ValidateStartDate(DateTime? startDate, ValidationContext context)
        {
            if (startDate.HasValue && startDate.Value < DateTime.Now)
            {
                return new ValidationResult("Start date cannot be in the past.");
            }

            return ValidationResult.Success;
        }

        public List<Guid> ScreenTypeIds { get; set; } = new List<Guid>();
        public List<Guid> TranslationTypeIds { get; set; } = new List<Guid>();

    }
}