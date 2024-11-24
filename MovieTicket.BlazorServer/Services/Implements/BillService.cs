﻿using Microsoft.AspNetCore.WebUtilities;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class BillService : IBillService
    {
        private readonly HttpClient _http;

        public BillService(HttpClient http)
        {
            _http = http;
        }

		public async Task<BillDetailDto> GetBillByIdAsync(Guid billId)
		{
			var response = await _http.GetFromJsonAsync<BillDetailDto>($"api/Bill/GetById?id={billId}");
			return response;
		}

		public async Task<List<BillDto>> GetListBillAsync()
        {
            var response = await _http.GetFromJsonAsync<List<BillDto>>("api/Bill/GetAll");
            return response;
        }

		public async Task<PageList<BillsDto>> GetListBillWithPaginationAsync(BillWithPaginationRequest request, PagingParameters pagingParameters)
		{
			var queryParameters = new Dictionary<string, string>
			{
				["pageNumber"] = pagingParameters.PageNumber.ToString(),
				["pageSize"] = pagingParameters.PageSize.ToString()
			};
			if (!String.IsNullOrEmpty(request.FilmName))
			{
				queryParameters.Add("FilmName", request.FilmName.ToString());
			}
			if (!String.IsNullOrEmpty(request.BarCode))
			{
				queryParameters.Add("BarCode", request.BarCode.ToString());
			}
			if (!String.IsNullOrEmpty(request.CinemaType_Name))
			{
				queryParameters.Add("CinemaType_Name", request.CinemaType_Name.ToString());
			}
			if (request.Type.HasValue)
			{
				queryParameters.Add("Type", request.Type.ToString());
			}
			if (request.Status.HasValue)
			{
				queryParameters.Add("Status", request.Status.ToString());
			}
			if (request.StartTime != null && request.EndTime != null)
			{
				queryParameters.Add("StartTime", request.StartTime.ToString());
				queryParameters.Add("EndTime", request.EndTime.ToString());
			}
			string url = QueryHelpers.AddQueryString("api/Bill/GetListBillWithPagination", queryParameters);
			var result = await _http.GetFromJsonAsync<PageList<BillsDto>>(url);
			return result ?? new PageList<BillsDto>
			{
				Item = new List<BillsDto>(),
			};
		}
	}
}
