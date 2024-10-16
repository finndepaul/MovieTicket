using MovieTicket.Application.DataTransferObjs.Cinema;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class CinemaService : ICinemaService
    {
        private readonly HttpClient _httpClient;

        public CinemaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseObject<CinemaDto>> GetCinemaById(Guid id)
        {
            var respone = await _httpClient.GetFromJsonAsync<ResponseObject<CinemaDto>>($"api/Cinema/GetById?id={id}");
            return respone;
        }

        public async Task<IQueryable<CinemaDto>> GetCinemasAsync(string? cinemaCenterName, string? name)
        {
            // Tạo URL cơ bản
            var url = "api/Cinema/GetAll";

            // Kiểm tra tham số cinemaCenterName
            if (string.IsNullOrEmpty(cinemaCenterName))
            {
                throw new ArgumentException("cinemaCenterName is required", nameof(cinemaCenterName));
            }

            // Thêm tham số cinemaCenterName vào URL
            url += $"?cinemaCenterName={Uri.EscapeDataString(cinemaCenterName)}";

            // Nếu name không null, thêm tham số truy vấn vào URL
            if (!string.IsNullOrEmpty(name))
            {
                url += $"&name={Uri.EscapeDataString(name)}"; // Sử dụng & để thêm tham số mới
            }

            Console.WriteLine($"Calling API at: {url}");

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<CinemaDto>>();
                return result.AsQueryable();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error fetching cinemas: {response.StatusCode}, {errorContent}");
            }
        }



    }
}