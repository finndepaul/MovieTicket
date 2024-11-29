using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Coupon;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
	public class CouponReadOnlyRepository : ICouponReadOnlyRepository
	{
		private readonly MovieTicketReadOnlyDbContext _db;

		public CouponReadOnlyRepository(MovieTicketReadOnlyDbContext db)
		{
			_db = db;
		}

		public async Task<PageList<CouponDto>> GetAllAsync(string? couponCode, DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters, CancellationToken cancellationToken)
		{
			startDate ??= DateTime.Now;
			endDate ??= DateTime.Now;
			var query = _db.Coupons.Select(x => new CouponDto
			{
				CouponCode = x.CouponCode,
				AmountValue = x.AmountValue,
				StartDate = x.StartDate,
				EndDate = x.EndDate,
				IsActive = x.IsActive ? "Đang hoạt đông" : "Ngưng hoạt động"
			})
			.AsNoTracking()
			.AsQueryable();
			query = query.Where(x => x.StartDate >= startDate && x.EndDate <= endDate);
			if (!string.IsNullOrEmpty(couponCode))
			{
				query = query.Where(x => x.CouponCode.Contains(couponCode));
			}
			int count = await query.CountAsync(cancellationToken);
			var data = await query.Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
				.Take(pagingParameters.PageSize)
				.AsNoTracking()
				.ToListAsync(cancellationToken);
			return new PageList<CouponDto>(data, count, pagingParameters.PageNumber, pagingParameters.PageSize);
		}
	}
}