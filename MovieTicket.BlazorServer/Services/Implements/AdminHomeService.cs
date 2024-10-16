using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using MovieTicket.Application.DataTransferObjs.AdminHome;

using System.Net.Http.Json;

namespace MovieTicket.BlazorServer.Services.Implements
{
	public class AdminHomeService : IAdminHomeService
	{
		private readonly HttpClient _httpClient;

        public AdminHomeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<byte[]> ExportRevenueCinemaDtoToExcel(DateTime? startDate, DateTime? endDate)
        {
            var queryParameters = new Dictionary<string, string>
            {
                ["startDate"] = startDate.ToString(),
                ["endDate"] = endDate.ToString()
            };
            string url = QueryHelpers.AddQueryString("api/AdminHome/ExportRevenueCinemaDtoToExcel", queryParameters);
            var result = await _httpClient.GetByteArrayAsync(url);
            return result;
        }

        public async Task<byte[]> ExportRevenueMovieDtoToExcel(DateTime? startDate, DateTime? endDate)
        {
            var queryParameters = new Dictionary<string, string>
            {
                ["startDate"] = startDate.ToString(),
                ["endDate"] = endDate.ToString()
            };
            string url = QueryHelpers.AddQueryString("api/AdminHome/ExportRevenueMovieDtoToExcel", queryParameters);
            var result = await _httpClient.GetByteArrayAsync(url);
            return result;
        }

        public async Task<GeneralDto> GetAdminGeneralAsync()
		{
			var result = await _httpClient.GetFromJsonAsync<GeneralDto>("api/AdminHome/GetAdminGeneral");
			return result;
		}

		public async Task<PageList<RevenueByCinemaDto>> GetListRevenueByCinemaAsync(DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters)
		{
			var queryParameters = new Dictionary<string, string>
			{
				["startDate"] = startDate.ToString(),
				["endDate"] = endDate.ToString(),
				["pageNumber"] = pagingParameters.PageNumber.ToString(),
				["pageSize"] = pagingParameters.PageSize.ToString()
			};
			string url = QueryHelpers.AddQueryString("api/AdminHome/GetListRevenueByCinema", queryParameters);
			var result = await _httpClient.GetFromJsonAsync<PageList<RevenueByCinemaDto>>(url);
			return result;
		}

		public async Task<PageList<RevenueByMovieDto>> GetListRevenueByMovieAsync(DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters)
		{
			var queryParameters = new Dictionary<string, string>
			{
				["startDate"] = startDate.ToString(),
				["endDate"] = endDate.ToString(),
				["pageNumber"] = pagingParameters.PageNumber.ToString(),
				["pageSize"] = pagingParameters.PageSize.ToString()
			};
			string url = QueryHelpers.AddQueryString("api/AdminHome/GetListRevenueByMovie", queryParameters);
			var result = await _httpClient.GetFromJsonAsync<PageList<RevenueByMovieDto>>(url);
			return result;
		}

        public async Task<List<RevenueByMonthDto>> RevenueByMonthDto()
        {
            var result = await _httpClient.GetFromJsonAsync<List<RevenueByMonthDto>>($"api/AdminHome/RevenueByMonthDto");
            return result;
        }
    }
}

