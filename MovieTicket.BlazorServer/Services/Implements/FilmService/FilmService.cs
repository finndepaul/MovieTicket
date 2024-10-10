﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.DataTransferObjs.ScreenType;
using MovieTicket.Application.DataTransferObjs.TranslationType;
using MovieTicket.BlazorServer.Services.Interfaces.IFilmService;
using MovieTicket.Domain.Entities;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;

namespace MovieTicket.BlazorServer.Services.Implements.FilmService
{
    public class FilmService : IFilmService
    {
        private readonly HttpClient _httpClient;

        public FilmService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<FilmDto>> GetAllFilms()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<FilmDto>>("api/Film/GetAll");
        }

        public async Task<FilmDto> GetById(Guid id)
        {
            var film = await _httpClient.GetFromJsonAsync<FilmDto>($"api/Film/GetById?id={id}");

            return film;

        }

        public async Task<FilmDto> CreateFilm(FilmCreateRequest filmCreateRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Film/Create", filmCreateRequest);
            return await response.Content.ReadFromJsonAsync<FilmDto>();
        }

        public async Task<FilmDto> UpdateFilm(Guid id, FilmUpdateRequest filmUpdateRequest)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Film/Update?id={id}", filmUpdateRequest);
            return await response.Content.ReadFromJsonAsync<FilmDto>();
        }

        public async Task<FilmDto> DeleteFilm(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/Film/Delete?id={id}");
            return await response.Content.ReadFromJsonAsync<FilmDto>();
        }
    }
}
