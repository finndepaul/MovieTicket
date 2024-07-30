using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.DataTransferObjs
{
    public class FilmUpdateRequest
    {
        public string? Name { get; set; }

        public string? EnglishName { get; set; }

        public string? Trailer { get; set; }

        public string? Description { get; set; }

        public string? Gerne { get; set; }

        public string? Director { get; set; }

        public string? Cast { get; set; }

        public Guid? ScreenTypeId { get; set; }

        public Guid? TranslationTypeId { get; set; }

        public int? Rating { get; set; }

        public DateTime? StartDate { get; set; }

        public int? ReleaseYear { get; set; }

        public int? RunningTime { get; set; }

        public FilmStatus? Status { get; set; }

        public string? Nation { get; set; }

        public string? Poster { get; set; }

        public string? Language { get; set; }

        
    }
}
