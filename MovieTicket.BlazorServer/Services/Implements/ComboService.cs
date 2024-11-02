﻿using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class ComboService : IComboService
    {
        private readonly HttpClient _httpClient;

        public ComboService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ComboDto> Create(CreateComboRequest combo)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Combo/Create", combo);
            return await response.Content.ReadFromJsonAsync<ComboDto>();
        }

        public async Task<ComboDto> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/Combo/Delete?id={id}");
            return await response.Content.ReadFromJsonAsync<ComboDto>();
        }

        public async Task<List<ComboDto>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<ComboDto>>("api/Combo/GetAll");
        }

        public async Task<ComboDto> GetById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<ComboDto>($"api/Combo/GetById?id={id}");
        }

        public async Task<ComboDto> Update(Guid id, UpdateComboRequest combo)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Combo/Update?id={id}", combo);
            return await response.Content.ReadFromJsonAsync<ComboDto>();
        }
    }
}