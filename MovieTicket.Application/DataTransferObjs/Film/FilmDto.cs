using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.DataTransferObjs.Film
{
    public class FilmDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? EnglishName { get; set; }

        public string? Trailer { get; set; }

        public string? Description { get; set; }

        public string? Gerne { get; set; }

        public string? Director { get; set; }

        public string? Cast { get; set; }

        public int? Rating { get; set; }

        public DateTime? StartDate { get; set; }

        public int? ReleaseYear { get; set; }

        public int? RunningTime { get; set; }

        public FilmStatus? Status { get; set; }

        public string? Nation { get; set; }

        public string? Poster { get; set; }

        public string? Language { get; set; }

        public DateTime? CreatDate { get; set; }

        public List<Guid>? ScreenTypeIds { get; set; } = new List<Guid>();

        public List<Guid>? TranslationTypeIds { get; set; } = new List<Guid>();

    }
}