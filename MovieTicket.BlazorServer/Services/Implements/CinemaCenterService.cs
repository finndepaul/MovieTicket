using Microsoft.AspNetCore.WebUtilities;
using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class CinemaCenterService : ICinemaCenterService
    {
        private readonly HttpClient _httpClient;

        public CinemaCenterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ResponseObject<CinemaCenterDto>> GetCinemaCenterById(Guid id)
        {
            throw new NotImplementedException();
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


    }
}