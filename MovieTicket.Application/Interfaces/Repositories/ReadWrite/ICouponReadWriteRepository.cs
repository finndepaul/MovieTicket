using MovieTicket.Application.DataTransferObjs.Coupon;
using MovieTicket.Application.DataTransferObjs.Coupon.Requests;
using MovieTicket.Application.ValueObjs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
	public interface ICouponReadWriteRepository
	{
		Task<ResponseObject<CouponDto>> CreateAsync(CreateCouponRequest request, CancellationToken cancellationToken);

		Task<ResponseObject<CouponDto>> UpdateAsync(UpdateCouponRequest request, CancellationToken cancellationToken);

		Task<ResponseObject<CouponDto>> DeleteAsync(Guid couponId, CancellationToken cancellationToken);
	}
}