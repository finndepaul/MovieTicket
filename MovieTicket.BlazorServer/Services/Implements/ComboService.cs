using Microsoft.AspNetCore.WebUtilities;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.ValueObjs.Paginations;
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

        public async Task<ResponseObject<ComboDto>> Create(CreateComboRequest combo)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Combo/Create", combo);
            var readObj = await response.Content.ReadFromJsonAsync<ResponseObject<ComboDto>>();
            return new ResponseObject<ComboDto>
            {
                Data = readObj.Data,
                Message = readObj.Message,
                Status = readObj.Status
            };
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

        public async Task<PageList<ComboDto>> GetAllPaging(PagingParameters pagingParameters)
        {
            var queryParameters = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
                ["pageSize"] = pagingParameters.PageSize.ToString()
            };

            var url = QueryHelpers.AddQueryString("api/Combo/GetAllPaging", queryParameters);
            var response = await _httpClient.GetFromJsonAsync<PageList<ComboDto>>(url);
            return response ?? new PageList<ComboDto>
            {
                Item = new List<ComboDto>(),
            };
        }

        public async Task<ComboDto> GetById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<ComboDto>($"api/Combo/GetById?id={id}");
        }

        public async Task<ResponseObject<ComboDto>> Update(Guid id, UpdateComboRequest combo)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Combo/Update?id={id}", combo);
            var readObj = await response.Content.ReadFromJsonAsync<ResponseObject<ComboDto>>();
            return new ResponseObject<ComboDto>
            {
                Data = readObj.Data,
                Message = readObj.Message,
                Status = readObj.Status
            };
        }
    }
}