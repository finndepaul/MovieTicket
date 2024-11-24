using Microsoft.AspNetCore.WebUtilities;
using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.BlazorServer.Services.Interfaces;
using ZXing;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class FilmService : IFilmService
    {
        private readonly HttpClient _httpClient;

        public FilmService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PageList<FilmDto>> GetAllPaging(PagingParameters pagingParameters)
        {
            var queryParameters = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
                ["pageSize"] = pagingParameters.PageSize.ToString()
            };

            var url = QueryHelpers.AddQueryString("api/Film/GetAllPaging", queryParameters);
            var response = await _httpClient.GetFromJsonAsync<PageList<FilmDto>>(url);
            return response ?? new PageList<FilmDto>
            {
                Item = new List<FilmDto>(),
            };
        }

        public async Task<FilmDto> GetById(Guid id)
        {
            var film = await _httpClient.GetFromJsonAsync<FilmDto>($"api/Film/GetById?id={id}");

            return film;

        }

        public async Task<FilmDto> CreateFilm(FilmCreateRequest filmCreateRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Film/Create", filmCreateRequest);
            return await response.Content.ReadFromJsonAsync<FilmDto>();
        }

        public async Task<FilmDto> UpdateFilm(Guid id, FilmUpdateRequest filmUpdateRequest)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Film/Update?id={id}", filmUpdateRequest);
            return await response.Content.ReadFromJsonAsync<FilmDto>();
        }


        public async Task<ResponseObject<FilmDto>> DeleteFilm(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/Film/Delete?id={id}");
            var readObj = await response.Content.ReadFromJsonAsync<ResponseObject<FilmDto>>();
            return new ResponseObject<FilmDto>()
            {
                Data = readObj.Data,
                Message = readObj.Message,
                Status = readObj.Status
            };
        }

        public Task<IEnumerable<FilmDto>> GetAllFilms()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<FilmDto>>("api/Film/GetAll");
        }


        public async Task<PageList<FilmDto>> GetFiltering(string? name, int? releaseYear, DateTime? createDate, DateTime? startDate, PagingParameters pagingParameters)
        {
            var queryParameters = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
                ["pageSize"] = pagingParameters.PageSize.ToString()
            };

            if (!string.IsNullOrEmpty(name))
            {
                queryParameters["name"] = name;
            }

            if (releaseYear.HasValue)
            {
                queryParameters["releaseYear"] = releaseYear.Value.ToString();
            }

            if (createDate.HasValue)
            {
                queryParameters["createDate"] = createDate.Value.ToString("yyyy-MM-dd");
            }

            if (startDate.HasValue)
            {
                queryParameters["startDate"] = startDate.Value.ToString("yyyy-MM-dd");
            }
            var url = QueryHelpers.AddQueryString("api/Film/FilteringFilms", queryParameters);
            var response = await _httpClient.GetFromJsonAsync<PageList<FilmDto>>(url);
            return response ?? new PageList<FilmDto>
            {
                Item = new List<FilmDto>(),
            };
        }

    }
}
