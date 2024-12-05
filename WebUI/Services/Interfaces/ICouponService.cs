using MovieTicket.Application.DataTransferObjs.Coupon;
using MovieTicket.Application.DataTransferObjs.Coupon.Requests;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace WebUI.Services.Interfaces
{
    public interface ICouponService
    {
        Task<PageList<CouponDto>> GetAllAsync(string? couponCode, DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters, CancellationToken cancellationToken);

        Task<UpdateCouponRequest> GetCouponForUpdate(Guid id, CancellationToken cancellationToken);

        Task<ResponseObject<CouponDto>> CreateAsync(CreateCouponRequest request, CancellationToken cancellationToken);

        Task<ResponseObject<CouponDto>> UpdateAsync(UpdateCouponRequest request, CancellationToken cancellationToken);

        Task<ResponseObject<CouponDto>> DeleteAsync(Guid couponId, CancellationToken cancellationToken);
    }
}