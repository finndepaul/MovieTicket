using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.AdminHome;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
	public class AdminHomeReadOnlyRepository : IAdminHomeReadOnlyRepository
	{
		private readonly MovieTicketReadOnlyDbContext _db;
		private readonly DateTime time = DateTime.Now;
		public AdminHomeReadOnlyRepository(MovieTicketReadOnlyDbContext db)
		{
			_db = db;
		}

		public async Task<GeneralDto> GetAdminGeneralAsync()
		{
			var lstBill = _db.Bills.AsNoTracking();
			//var lstMembership = _db.Memberships.AsNoTracking();
			//Lấy tháng hiện tại
			var monthNow = time.Month;
			//Lấy ngày hiện tại
			var today = time.Date;
			int countNewCustomer = 0;

			//Đếm tổng số vé đã bán trong tháng
			var countBillByMonth = await lstBill.Where(x => x.CreateTime.Month == monthNow).CountAsync();
			//Tính tổng doanh thu trong tháng
			var totalRevenuaByMonth = await lstBill.Where(x => x.CreateTime.Month == monthNow).SumAsync(x => x.TotalMoney);
			//Tính doanh thu hàng ngày
			var dailyRevenua = await lstBill.Where(x => x.CreateTime.Date == today).SumAsync(x => x.TotalMoney);
			//Tính số lượng khách hàng mới
			var lstMembership = lstBill.GroupBy(x => x.MembershipId).Where(x => x.Count() == 1).Select(g => new { MembershipId = g.Key, Count = g.Count(), });
			foreach (var item in lstMembership)
			{
				countNewCustomer++;
			}
			var listObjMonth = lstBill.Where(x => x.CreateTime.Month == monthNow);

			return new GeneralDto()
			{
				NewCustomer = countNewCustomer,
				DailyRevenue = dailyRevenua,
				TotalTicketsSold = countBillByMonth,
				TotalRevenue = totalRevenuaByMonth,
			};
		}

		public async Task<IQueryable<RevenueByCinemaDto>> GetListRevenueByCinemaAsync(DateTime? startDate, DateTime? endDate)
		{
			//Lấy danh sách bill
			var lstBill = _db.Bills.AsNoTracking();
			//Lấy danh sách vé
			var lstTicket = _db.Tickets.AsNoTracking();
			//join bảng
			var query = await lstBill.Join(lstTicket, b => b.Id, t => t.BillId, (b, t) => new { b, t })
				.GroupBy(x => x.t.CinemaCenterId)
				.OrderByDescending(x => x.Sum(x => x.b.TotalMoney))
				.Where(x => x.FirstOrDefault().b.CreateTime >= startDate && x.FirstOrDefault().b.CreateTime <= endDate)
				.Select(x => new RevenueByCinemaDto
				{
					Name = x.FirstOrDefault().t.CinemaCenter.Name,
					TotalTicket = x.Count(),
					TotalRevenue = x.Sum(x => x.b.TotalMoney)
				})
				.ToListAsync();

			return query.AsQueryable();
		}

		public async Task<IQueryable<RevenueByMovieDto>> GetListRevenueByMovieAsync(DateTime? startDate, DateTime? endDate)
		{
			var lstBill = _db.Bills.AsNoTracking();
			var lstTicket = _db.Tickets.AsNoTracking();
			var lstShowTime = _db.ShowTimes.AsNoTracking();
			var query = await lstBill.Join(lstTicket, b => b.Id, t => t.BillId, (b, t) => new { b, t })
				.Join(lstShowTime, b => b.t.ShowTimeId, s => s.Id, (b, s) => new { b, s })
				.GroupBy(x => x.s.FilmId)
				.OrderByDescending(x => x.Sum(x => x.b.b.TotalMoney))
				.Where(x => x.FirstOrDefault().b.b.CreateTime >= startDate && x.FirstOrDefault().b.b.CreateTime <= endDate)
				.Select(x => new RevenueByMovieDto
				{
					FilmName = x.FirstOrDefault().s.Film.Name,
					TotalTicket = x.Count(),
					TotalRevenue = x.Sum(x => x.b.b.TotalMoney)
				}
			).ToListAsync();
			return query.AsQueryable();

		}
	}
}
