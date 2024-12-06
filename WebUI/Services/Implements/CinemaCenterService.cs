using Microsoft.AspNetCore.WebUtilities;
using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
using WebUI.Services.Interfaces;
using MovieTicket.Domain.Entities;
using System.Net.Http.Json;

namespace WebUI.Services.Implements
{
    public class CinemaCenterService : ICinemaCenterService
    {
        private readonly HttpClient _httpClient;

        public CinemaCenterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseObject<CinemaCenter>> Create(CinemaCenterCreateRequest cinemaCenter)
        {
            var result = await _httpClient.PostAsJsonAsync("api/CinemaCenter/Create", cinemaCenter);
            var readObj = await result.Content.ReadFromJsonAsync<ResponseObject<CinemaCenter>>();
            return new ResponseObject<CinemaCenter>
            {
                Data = readObj.Data,
                Message = readObj.Message,
                Status = readObj.Status
            };
        }

        public async Task<ResponseObject<CinemaCenter>> Delete(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/CinemaCenter/Delete?id={id}");
            var readObj = await result.Content.ReadFromJsonAsync<ResponseObject<CinemaCenter>>();
            return new ResponseObject<CinemaCenter>
            {
                Data = readObj.Data,
                Message = readObj.Message,
                Status = readObj.Status
            };
        }

        public async Task<PageList<CinemaCenterDto>> GetAllCinemaCenter(CinemaCenterSearch search, PagingParameters pagingParameters)
        {
            var queryParam = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
                ["pageSize"] = pagingParameters.PageSize.ToString()
            };
            if (!string.IsNullOrEmpty(search.Name))
            {
                queryParam.Add("name", search.Name.ToString());
            }
            if (!string.IsNullOrEmpty(search.Address))
            {
                queryParam.Add("address", search.Address.ToString());
            }
            if (!string.IsNullOrEmpty(search.AddresCity))
            {
                queryParam.Add("addresCity", search.AddresCity.ToString());
            }
            string url = QueryHelpers.AddQueryString("api/CinemaCenter/GetAllCinemaCenter", queryParam);
            var result = await _httpClient.GetFromJsonAsync<PageList<CinemaCenterDto>>(url);
            return result;
        }

        public async Task<ResponseObject<CinemaCenterDto>> GetCinemaCenterById(Guid id)
        {
            var result = await _httpClient.GetFromJsonAsync<ResponseObject<CinemaCenterDto>>($"api/CinemaCenter/GetById?id={id}");
            return result;
        }

        public async Task<IQueryable<CinemaCenterDto>> GetCinemaCentersAsync(CinemaCenterSearch search)
        {
            // Bắt đầu với URL cơ bản
            var url = "api/CinemaCenter/GetAll";

            // Danh sách để lưu các tham số truy vấn
            var queryParams = new List<string>();

            // Thêm tham số truy vấn nếu có
            if (!string.IsNullOrEmpty(search.Name))
            {
                queryParams.Add($"Name={Uri.EscapeDataString(search.Name)}");
            }

            if (!string.IsNullOrEmpty(search.Address))
            {
                queryParams.Add($"Address={Uri.EscapeDataString(search.Address)}");
            }

            // Nếu có tham số truy vấn, thêm vào URL
            if (queryParams.Count > 0)
            {
                url += "?" + string.Join("&", queryParams);
            }

            // Gọi API và nhận kết quả
            var lst = await _httpClient.GetFromJsonAsync<List<CinemaCenterDto>>(url);

            // Chuyển đổi danh sách thành IQueryable
            return lst.AsQueryable();
        }

        public async Task<ResponseObject<CinemaCenter>> Update(Guid Id, CinemaCenterUpdateRequest cinemaCenter)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/CinemaCenter/Update?id={Id}", cinemaCenter);
            var readObj = await result.Content.ReadFromJsonAsync<ResponseObject<CinemaCenter>>();
            return new ResponseObject<CinemaCenter>
            {
                Data = readObj.Data,
                Message = readObj.Message,
                Status = readObj.Status
            };
        }
    }
}