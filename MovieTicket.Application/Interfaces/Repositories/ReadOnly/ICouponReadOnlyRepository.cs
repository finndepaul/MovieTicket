using MovieTicket.Application.DataTransferObjs.Coupon;
using MovieTicket.Application.ValueObjs.Paginations;
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
	}
}