using MovieTicket.Application.DataTransferObjs.Banner;
using MovieTicket.Application.ValueObjs.ViewModels;
using System.Net.Http.Json;
using WebUI.Services.Interfaces;

namespace WebUI.Services.Implements
{
    public class BannerService : IBannerService
    {
        private readonly HttpClient _httpClient;

        public BannerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseObject<BannerDTO>> Create(BannerCreateRequest banner)
        {
            var respone = await _httpClient.PostAsJsonAsync<BannerCreateRequest>("https://localhost:6868/api/Banner/CreateBanner", banner);
            var result = await respone.Content.ReadFromJsonAsync<ResponseObject<BannerDTO>>();
            return result;
        }

        public async Task<ResponseObject<BannerDTO>> GetById(Guid id)
        {
            var respone = await _httpClient.GetFromJsonAsync<ResponseObject<BannerDTO>>($"https://localhost:6868/api/Banner/GetById?id={id}");
            return respone;
        }

        public async Task<List<BannerDTO>> GetBannersAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<BannerDTO>>("https://localhost:6868/api/Banner/GetAll");
            return result;
        }

        public async Task<ResponseObject<BannerDTO>> Update(BannerUpdateRequest banner)
        {
            var respone = await _httpClient.PutAsJsonAsync<BannerUpdateRequest>("https://localhost:6868/api/Banner/UpdateBanner", banner);
            var result = await respone.Content.ReadFromJsonAsync<ResponseObject<BannerDTO>>();
            return result;
        }

        public async Task<ResponseObject<BannerDTO>> Delete(Guid id)
        {
            var respone = await _httpClient.DeleteAsync($"https://localhost:6868/api/Banner/HardDelete?id={id}");
            var result = await respone.Content.ReadFromJsonAsync<ResponseObject<BannerDTO>>();
            return result;
        }
    }
}