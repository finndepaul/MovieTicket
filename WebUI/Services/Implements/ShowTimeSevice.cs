﻿using Microsoft.AspNetCore.WebUtilities;
using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
using WebUI.Services.Interfaces;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using System.Net.Http.Json;

namespace WebUI.Services.Implements
{
    public class ShowTimeSevice : IShowTimeService
    {
        private readonly HttpClient _httpClient;

        public ShowTimeSevice(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseObject<ShowTimeCreateRequest>> Create(ShowTimeCreateRequest showTime)
        {
            var result = await _httpClient.PostAsJsonAsync("api/ShowTime/Post", showTime);
            var readOje = await result.Content.ReadFromJsonAsync<ResponseObject<ShowTimeCreateRequest>>();
            return new ResponseObject<ShowTimeCreateRequest>()
            {
                Data = readOje.Data,
                Message = readOje.Message,
                Status = readOje.Status
            };
        }

        public async Task<ResponseObject<ShowTimeDto>> Delete(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/ShowTime/Delete?id={id}");
            var readObj = await result.Content.ReadFromJsonAsync<ResponseObject<ShowTimeDto>>();
            return new ResponseObject<ShowTimeDto>
            {
                Data = readObj.Data,
                Message = readObj.Message,
                Status = readObj.Status
            };
        }

        public async Task<PageList<ShowTimeDto>> GetAll(ShowTimeSearch? showTimeSearch, PagingParameters pagingParameters)
        {
            if (showTimeSearch == null ||
                (!showTimeSearch.CinemaCenterId.HasValue &&
                 !showTimeSearch.CinemaId.HasValue &&
                 !showTimeSearch.ShowtimeDate.HasValue))
            {
                return new PageList<ShowTimeDto>
                {
                    Item = new List<ShowTimeDto>()
                };
            }

            var queryParam = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
                ["pageSize"] = pagingParameters.PageSize.ToString()
            };

            if (showTimeSearch.CinemaCenterId.HasValue)
            {
                queryParam.Add("cinemaCenterId", showTimeSearch.CinemaCenterId.ToString());
            }
            if (showTimeSearch.CinemaId.HasValue)
            {
                queryParam.Add("cinemaId", showTimeSearch.CinemaId.ToString());
            }
            if (showTimeSearch.ShowtimeDate.HasValue)
            {
                queryParam.Add("showtimeDate", showTimeSearch.ShowtimeDate.Value.ToString());
            }

            string url = QueryHelpers.AddQueryString("api/ShowTime/GetAll", queryParam);
            var result = await _httpClient.GetFromJsonAsync<PageList<ShowTimeDto>>(url);

            return result ?? new PageList<ShowTimeDto>
            {
                Item = new List<ShowTimeDto>(),
            };
        }

        public async Task<ResponseObject<ShowTimeDto>> GetById(Guid id)
        {
            var response = await _httpClient.GetFromJsonAsync<ResponseObject<ShowTimeDto>>($"api/ShowTime/GetById?id={id}");
            return response;
        }

        public async Task<ResponseObject<ShowTimeUpdateRequest>> Update(ShowTimeUpdateRequest showTime)
        {
            var result = await _httpClient.PutAsJsonAsync("api/ShowTime/Put", showTime);
            var readObj = await result.Content.ReadFromJsonAsync<ResponseObject<ShowTimeUpdateRequest>>();
            return new ResponseObject<ShowTimeUpdateRequest>
            {
                Data = readObj.Data,
                Message = readObj.Message,
                Status = readObj.Status
            };
        }

		public async Task<ResponseObject<ShowTimeDto>> UpdateStatus(ShowTimeUpdateStatus updateStatus)
		{
			var result = await _httpClient.PutAsJsonAsync($"api/ShowTime/UpdateStatus/", updateStatus);
			var readObj = await result.Content.ReadFromJsonAsync<ResponseObject<ShowTimeDto>>();
			return new ResponseObject<ShowTimeDto>
			{
				Data = readObj.Data,
				Message = readObj.Message,
				Status = readObj.Status
			};
		}
	}
}