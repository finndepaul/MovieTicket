using MovieTicket.Domain.Enums;
using System;
using System.Collections.Generic;

namespace MovieTicket.Domain.Entities;

public class Film
{
    public Guid Id { get; set; }

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

    public DateOnly? StartDate { get; set; }

    public int? ReleaseYear { get; set; }

    public int? RunningTime { get; set; }

    public FilmStatus? Status { get; set; }

    public string? Nation { get; set; }

    public string? Poster { get; set; }

    public string? Language { get; set; }

    public DateOnly? CreatDate { get; set; }

    public virtual ICollection<ShowTime> ShowTimes { get; set; } = new List<ShowTime>();
    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    public virtual ICollection<FilmScreenType> FilmScreenTypes { get; set; } = new List<FilmScreenType>();
    public virtual ICollection<FilmTranslationType> FilmTranslationTypes { get; set; } = new List<FilmTranslationType>();
}
