﻿using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class FilmReadOnlyRepostitory : IFilmReadOnlyRepository
    {
        private MovieTicketReadWriteDbContext context;
        public FilmReadOnlyRepostitory()
        {
            context = new MovieTicketReadWriteDbContext();
        }
        public async Task<IQueryable<FilmDto>> GetAllFilm()
        {   
            var films = context.Films.Where(films => films.Status != FilmStatus.Ended).Select(film => new FilmDto
            {
                Id = film.Id,
                Name = film.Name,
                EnglishName = film.EnglishName,
                Trailer = film.Trailer,
                Description = film.Description,
                Gerne = film.Gerne,
                Director = film.Director,
                Cast = film.Cast,
                ScreenTypeId = film.ScreenTypeId,
                TranslationTypeId = film.TranslationTypeId,
                Rating = film.Rating,
                StartDate = film.StartDate,
                ReleaseYear = film.ReleaseYear,
                RunningTime = film.RunningTime,
                Status = film.Status,
                Nation = film.Nation,
                Poster = film.Poster,
                Language = film.Language,
                CreatDate = film.CreatDate
            });
            return films;
        }

        public async Task<FilmDto> GetFilmById(Guid id)
        {
            var film = context.Films.Where(film => film.Id == id).Select(film => new FilmDto
            {
                Id = film.Id,
                Name = film.Name,
                EnglishName = film.EnglishName,
                Trailer = film.Trailer,
                Description = film.Description,
                Gerne = film.Gerne,
                Director = film.Director,
                Cast = film.Cast,
                ScreenTypeId = film.ScreenTypeId,
                TranslationTypeId = film.TranslationTypeId,
                Rating = film.Rating,
                StartDate = film.StartDate,
                ReleaseYear = film.ReleaseYear,
                RunningTime = film.RunningTime,
                Status = film.Status,
                Nation = film.Nation,
                Poster = film.Poster,
                Language = film.Language,
                CreatDate = film.CreatDate
            }).FirstOrDefault();
            return film;
        }
    }
}
