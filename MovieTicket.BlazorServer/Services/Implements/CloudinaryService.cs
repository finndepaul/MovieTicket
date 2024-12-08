using MovieTicket.Application.DataTransferObjs.Cloudinary;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly HttpClient _httpClient;

        public CloudinaryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> UploadImageAsync(MultipartFormDataContent content)
        {
            try
            {
                var response = await _httpClient.PostAsync("api/Cloudinary/UploadImage", content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<UploadImageResponse>();
                    return result?.Link;
                }
                else
                {
                    // Log lỗi nếu API trả về trạng thái lỗi
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Cloudinary Error: {response.StatusCode} - {error}");
                }
            }
            catch (Exception ex)
            {
                // Log lỗi kết nối
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return null;
        }

    }
}
