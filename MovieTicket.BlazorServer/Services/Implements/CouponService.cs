using Microsoft.AspNetCore.WebUtilities;
using MovieTicket.Application.DataTransferObjs.Coupon;
using MovieTicket.Application.DataTransferObjs.Coupon.Requests;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class CouponService : ICouponService
    {
        private readonly HttpClient _http;

        public CouponService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResponseObject<CouponDto>> CreateAsync(CreateCouponRequest request, CancellationToken cancellationToken)
        {
            var result = await _http.PostAsJsonAsync("api/Coupon/Create", request, cancellationToken);
            var response = await result.Content.ReadFromJsonAsync<ResponseObject<CouponDto>>();
            return new ResponseObject<CouponDto>
            {
                Message = response.Message,
                Status = response.Status,
                Data = response.Data
            };
        }

        public async Task<ResponseObject<CouponDto>> DeleteAsync(Guid couponId, CancellationToken cancellationToken)
        {
            var result = await _http.DeleteAsync($"api/Coupon/Delete?couponId={couponId}", cancellationToken);
            var response = await result.Content.ReadFromJsonAsync<ResponseObject<CouponDto>>();
            return new ResponseObject<CouponDto>
            {
                Message = response.Message,
                Status = response.Status,
                Data = response.Data
            };
        }

        public async Task<PageList<CouponDto>> GetAllAsync(string? couponCode, DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters, CancellationToken cancellationToken)
        {
            var queryParameters = new Dictionary<string, string>
            {
                ["pageNumber"] = pagingParameters.PageNumber.ToString(),
                ["pageSize"] = pagingParameters.PageSize.ToString(),
                ["startDate"] = startDate?.ToString("yyyy-MM-dd"),
                ["endDate"] = endDate?.ToString("yyyy-MM-dd")
            };
            if (!string.IsNullOrEmpty(couponCode))
            {
                queryParameters.Add("couponCode", couponCode);
            }
            string url = QueryHelpers.AddQueryString("api/Coupon/GetAll", queryParameters);
            var result = await _http.GetFromJsonAsync<PageList<CouponDto>>(url);
            return result;
        }

        public async Task<ResponseObject<CouponDto>> UpdateAsync(UpdateCouponRequest request, CancellationToken cancellationToken)
        {
            var result = await _http.PutAsJsonAsync("api/Coupon/Update", request, cancellationToken);
            var response = await result.Content.ReadFromJsonAsync<ResponseObject<CouponDto>>();
            return new ResponseObject<CouponDto>
            {
                Message = response.Message,
                Status = response.Status,
                Data = response.Data
            };
        }
    }
}