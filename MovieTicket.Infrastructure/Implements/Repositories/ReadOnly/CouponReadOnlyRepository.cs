using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Coupon;
using MovieTicket.Application.DataTransferObjs.Coupon.Requests;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
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
			var query = _db.Coupons.AsNoTracking();

			if (startDate.HasValue)
			{
				query = query.Where(x => x.StartDate >= startDate.Value);
			}

			if (endDate.HasValue)
			{
				query = query.Where(x => x.EndDate <= endDate.Value);
			}

			if (!string.IsNullOrEmpty(couponCode))
			{
				query = query.Where(x => x.CouponCode.Contains(couponCode));
			}

			// Sắp xếp theo trạng thái
			query = query.OrderByDescending(x => x.IsActive);

			var dtoQuery = query.Select(x => new CouponDto
			{
				Id = x.Id,
				CouponCode = x.CouponCode,
				AmountValue = x.AmountValue,
				StartDate = x.StartDate,
				EndDate = x.EndDate,
				IsActive = x.IsActive ? "Đang hoạt động" : "Ngưng hoạt động"
			});

			int count = await dtoQuery.CountAsync(cancellationToken);

			var data = await dtoQuery
				.Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
				.Take(pagingParameters.PageSize)
				.ToListAsync(cancellationToken);

			return new PageList<CouponDto>(data, count, pagingParameters.PageNumber, pagingParameters.PageSize);
		}

		public async Task<UpdateCouponRequest> GetCouponForUpdate(Guid id, CancellationToken cancellationToken)
        {
            var result = await _db.Coupons
                    .AsNoTracking()
                    .Where(x => x.Id == id)
                    .Select(x => new UpdateCouponRequest
                    {
                        Id = x.Id,
                        CouponCode = x.CouponCode,
                        AmountValue = x.AmountValue,
                        StartDate = x.StartDate,
                        EndDate = x.EndDate,
                        IsActive = x.IsActive
                    })
                    .FirstOrDefaultAsync(cancellationToken);
            return result;
        }
    }
}