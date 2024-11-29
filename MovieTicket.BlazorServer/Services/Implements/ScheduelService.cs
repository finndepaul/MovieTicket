﻿using MovieTicket.Application.DataTransferObjs.Schedule.Request;
using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.BlazorServer.Services.Interfaces;
using MovieTicket.Application.ValueObjs.Paginations;
using Microsoft.AspNetCore.WebUtilities;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class ScheduelService : IScheduelService
    {
        private readonly HttpClient _http;

        public ScheduelService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CreateAsync(CreateScheduleRequest createScheduleRequest, CancellationToken cancellationToken)
        {
            var result = await _http.PostAsJsonAsync("api/Schedule/Create", createScheduleRequest, cancellationToken);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _http.DeleteAsync($"api/Schedule/Delete?id={id}", cancellationToken);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<PageList<ScheduleDto>> GetAllAsync(string? filmName, DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters, CancellationToken cancellationToken)
        {
            startDate ??= DateTime.Now;
            endDate ??= DateTime.Now;
            var queryParameters = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
                ["pageSize"] = pagingParameters.PageSize.ToString(),
                ["startDate"] = startDate?.ToString("yyyy-MM-dd"),
                ["endDate"] = endDate?.ToString("yyyy-MM-dd")
            };
            if (!string.IsNullOrEmpty(filmName))
            {
                queryParameters.Add("filmName", filmName);
            }
            var url = QueryHelpers.AddQueryString("api/Schedule/GetAllPaging", queryParameters);
            var result = await _http.GetFromJsonAsync<PageList<ScheduleDto>>(url);
            return result ?? new PageList<ScheduleDto>
            {
                Item = new List<ScheduleDto>()
            };
        }

        public async Task<IQueryable<FilmForCreateDto>> GetFilmAsync()
        {
            var lst = await _http.GetFromJsonAsync<List<FilmForCreateDto>>($"api/Schedule/GetFilmWithoutScheduel");
            return lst.AsQueryable();
        }

        public async Task<ScheduleDto> GetByIdAsync(Guid id)
        {
            var result = await _http.GetFromJsonAsync<ScheduleDto>($"api/Schedule/GetById?id={id}");
            return result;
        }

        public async Task<bool> UpdateAsync(UpdateScheduleRequest updateScheduleRequest, CancellationToken cancellationToken)
        {
            var result = await _http.PutAsJsonAsync($"api/Schedule/Update", updateScheduleRequest, cancellationToken);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public async Task<IQueryable<ScheduleDto>> GetAllAsync()
        {
            var lst = await _http.GetFromJsonAsync<List<ScheduleDto>>("api/Schedule/GetAll");
            return lst.AsQueryable();
        }
    }
}