using MovieTicket.Application.DataTransferObjs.Coupon;
using MovieTicket.Application.DataTransferObjs.Coupon.Requests;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface ICouponReadOnlyRepository
    {
        Task<PageList<CouponDto>> GetAllAsync(string? couponCode, DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters, CancellationToken cancellationToken);

        Task<UpdateCouponRequest> GetCouponForUpdate(Guid id, CancellationToken cancellationToken);
    }
}