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

        public async Task<List<CinemaCenterDto>> GetCinemaCentersAsync(CinemaCenterSearch search)
        {
            var parameters = new Dictionary<string, string>
            {
            };
            if (!string.IsNullOrEmpty(search.Name))
            {
                parameters.Add("Name", search.Name);
            }
            if (!string.IsNullOrEmpty(search.Address))
            {
                parameters.Add("Address", search.Address);
            }
            var url = QueryHelpers.AddQueryString("api/CinemaCenter/GetAll", parameters);
            var response = await _httpClient.GetFromJsonAsync<List<CinemaCenterDto>>(url);
            return response;
        }
    }
}