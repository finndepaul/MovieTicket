using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.AdminHome;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
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

        // Doanh thu theo tháng
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
            var countBillByMonth = await lstBill.Where(x => x.CreateTime.Month == monthNow && x.CreateTime.Year == DateTime.Now.Year).CountAsync();
            //Tính tổng doanh thu trong tháng
            var totalRevenuaByMonth = await lstBill.Where(x => x.CreateTime.Month == monthNow && x.CreateTime.Year == DateTime.Now.Year).SumAsync(x => x.TotalMoney);
            //Tính doanh thu hàng ngày
            var dailyRevenua = await lstBill.Where(x => x.CreateTime.Date == today && x.CreateTime.Year == DateTime.Now.Year).SumAsync(x => x.TotalMoney);
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

        // Doanh thu theo rạp
        public async Task<PageList<RevenueByCinemaDto>> GetListRevenueByCinemaAsync(DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters)
        {
            //Lấy danh sách bill
            var lstBill = _db.Bills.AsNoTracking();
            //Lấy danh sách vé
            var lstTicket = _db.Tickets.AsNoTracking();
            //join bảng lấy tất cả bản dữ liệu
            var lstShowTime = _db.ShowTimes.AsNoTracking();
            var lstCinema = _db.Cinemas.AsNoTracking();
			var query = await lstBill
               .Join(lstTicket, bill => bill.Id, ticket => ticket.BillId, (bill, ticket) => new { bill, ticket })
               .Join(lstShowTime, bt => bt.ticket.ShowTimeId, showtime => showtime.Id, (bt, showtime) => new { bt, showtime })
			   .Join(lstCinema, s => s.showtime.CinemaId, cinema => cinema.Id, (s, cinema) => new { s, cinema })
			   .GroupBy(x => x.cinema.CinemaCenterId)
               .OrderByDescending(x => x.Sum(x => x.s.bt.bill.AfterDiscount))
               .Where(x => x.FirstOrDefault().s.bt.bill.CreateTime >= startDate && x.FirstOrDefault().s.bt.bill.CreateTime <= endDate)
               .Select(x => new RevenueByCinemaDto
               {
                   Name = x.FirstOrDefault().cinema.CinemaCenter.Name,
                   TotalTicket = x.Count(),
                   TotalRevenue = x.Sum(x => x.s.bt.bill.AfterDiscount)
               }).ToListAsync();
            // Đếm tổng số phần tử
            var count = query.Count();
            //  phân trang
            var data = await lstBill
              .Join(lstTicket, bill => bill.Id, ticket => ticket.BillId, (bill, ticket) => new { bill, ticket })
			   .Join(lstShowTime, bt => bt.ticket.ShowTimeId, showtime => showtime.Id, (bt, showtime) => new { bt, showtime })
			   .Join(lstCinema, s => s.showtime.CinemaId, cinema => cinema.Id, (s, cinema) => new { s, cinema })
			   .GroupBy(x => x.cinema.CinemaCenterId)
			   .OrderByDescending(x => x.Sum(x => x.s.bt.bill.AfterDiscount))
			   .Where(x => x.FirstOrDefault().s.bt.bill.CreateTime >= startDate && x.FirstOrDefault().s.bt.bill.CreateTime <= endDate)
			   .Select(x => new RevenueByCinemaDto
			   {
				   Name = x.FirstOrDefault().cinema.CinemaCenter.Name,
				   TotalTicket = x.Count(),
				   TotalRevenue = x.Sum(x => x.s.bt.bill.AfterDiscount)
			   }).Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .ToListAsync();

            return new PageList<RevenueByCinemaDto>(data, count, pagingParameters.PageNumber, pagingParameters.PageSize);
        }

        // Doanh thu theo phim
        public async Task<PageList<RevenueByMovieDto>> GetListRevenueByMovieAsync(DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters)
        {
            var lstBill = _db.Bills.AsNoTracking();
            var lstTicket = _db.Tickets.AsNoTracking();
            var lstShowTime = _db.ShowTimes.AsNoTracking();
            var lstLC = _db.Schedules.AsNoTracking();
            var lstFilm = _db.Films.AsNoTracking();
            var query = await lstBill.Join(lstTicket, b => b.Id, t => t.BillId, (b, t) => new { b, t })
                .Join(lstShowTime, b => b.t.ShowTimeId, s => s.Id, (b, s) => new { b, s })
                .Join(lstLC, s => s.s.ScheduleId, lc => lc.Id, (s, lc) => new { s, lc })
                .Join(lstFilm, slc => slc.lc.FilmId, f => f.Id, (slc, f) => new { slc, f})
				.GroupBy(x => x.f.Id)
                .OrderByDescending(x => x.Sum(x => x.slc.s.b.b.AfterDiscount))
                .Where(x => x.FirstOrDefault().slc.s.b.b.CreateTime >= startDate && x.FirstOrDefault().slc.s.b.b.CreateTime <= endDate)
                .Select(x => new RevenueByMovieDto
                {
                    FilmName = x.FirstOrDefault().f.Name,
                    TotalTicket = x.Count(),
                    TotalRevenue = x.Sum(x => x.slc.s.b.b.AfterDiscount)
                }
            ).ToListAsync();
            var count = query.Count();
            var data = await lstBill.Join(lstTicket, b => b.Id, t => t.BillId, (b, t) => new { b, t })
				.Join(lstShowTime, b => b.t.ShowTimeId, s => s.Id, (b, s) => new { b, s })
				.Join(lstLC, s => s.s.ScheduleId, lc => lc.Id, (s, lc) => new { s, lc })
				.Join(lstFilm, slc => slc.lc.FilmId, f => f.Id, (slc, f) => new { slc, f })
				.GroupBy(x => x.f.Id)
				.OrderByDescending(x => x.Sum(x => x.slc.s.b.b.AfterDiscount))
				.Where(x => x.FirstOrDefault().slc.s.b.b.CreateTime >= startDate && x.FirstOrDefault().slc.s.b.b.CreateTime <= endDate)
				.Select(x => new RevenueByMovieDto
				{
					FilmName = x.FirstOrDefault().f.Name,
					TotalTicket = x.Count(),
					TotalRevenue = x.Sum(x => x.slc.s.b.b.AfterDiscount)
				}
			).Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                    .Take(pagingParameters.PageSize)
                    .ToListAsync();
            return new PageList<RevenueByMovieDto>(data, count, pagingParameters.PageNumber, pagingParameters.PageSize);
        }

        // Doanh thu tính theo 5 tháng
        public async Task<IQueryable<RevenueByMonthDto>> GetTopRevenueMonth()
        {
            var currentDate = DateTime.Now;
            var fiveMonthsAgo = currentDate.AddMonths(-4); // Lấy 4 tháng trước đó
            var totalRevenue = await _db.Bills
            .Where(b => b.CreateTime >= fiveMonthsAgo && b.CreateTime <= currentDate)  // Lọc trong khoảng thời gian 5 tháng
            .GroupBy(b => new { b.CreateTime.Year, b.CreateTime.Month })  // Nhóm theo tháng và năm
            .Select(g => new RevenueByMonthDto
            {
                Month = g.Key.Month,
                Year = g.Key.Year,
                TotalRevenue = g.Sum(x => x.TotalMoney)  // Tính tổng doanh thu cho từng tháng
            })
            .OrderBy(r => r.Year).ThenBy(r => r.Month)  // Sắp xếp theo thời gian từ tháng cũ nhất đến tháng mới nhất
            .ToListAsync();
            return totalRevenue.AsQueryable();
        }

        // Xuất file Excel CinemaDto
        public async Task<byte[]> ExportRevenueCinemaDtoToExcel(DateTime? startDate, DateTime? endDate)
        {
            // Lấy dữ liệu cần export (ví dụ dữ liệu doanh thu theo rạp)
            var response = await GetListRevenueByCinemaAsync(startDate, endDate, new PagingParameters { PageSize = int.MaxValue });
            var data = response.Item.ToList();  // Chuyển dữ liệu từ response thành danh sách

            // Tạo file Excel
            using (var package = new ExcelPackage())  // Sử dụng ExcelPackage để tạo và quản lý file Excel
            {
                // Tạo một worksheet mới có tên "Revenue"
                var worksheet = package.Workbook.Worksheets.Add("Revenue");

                // Đặt tiêu đề cho các cột
                worksheet.Cells[1, 1].Value = "Tên rạp";        // Cột 1: Tên rạp
                worksheet.Cells[1, 2].Value = "Tống vé bán ra"; // Cột 2: Tổng số vé bán ra
                worksheet.Cells[1, 3].Value = "Tổng tiền";      // Cột 3: Tổng doanh thu

                // Thêm dữ liệu vào Excel
                for (int i = 0; i < data.Count; i++)  // Duyệt qua danh sách data để thêm dữ liệu vào bảng
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].Name;         // Thêm Tên rạp vào cột 1, bắt đầu từ dòng 2
                    worksheet.Cells[i + 2, 2].Value = data[i].TotalTicket;  // Thêm tổng vé bán ra vào cột 2
                    worksheet.Cells[i + 2, 3].Value = data[i].TotalRevenue; // Thêm tổng doanh thu vào cột 3
                }

                // Ghi nội dung của file Excel vào bộ nhớ và trả về dưới dạng mảng byte
                return package.GetAsByteArray();
            }
        }

        // Xuất file excel MovieDto
        public async Task<byte[]> ExportRevenueMovieDtoToExcel(DateTime? startDate, DateTime? endDate)
        {
            // Lấy dữ liệu cần export (ví dụ dữ liệu doanh thu theo rạp)
            var response = await GetListRevenueByMovieAsync(startDate, endDate, new PagingParameters { PageSize = int.MaxValue });
            var data = response.Item.ToList();
            // Tạo file Excel
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Revenue");

                // Đặt tiêu đề cho cột
                worksheet.Cells[1, 1].Value = "Tên phim";
                worksheet.Cells[1, 2].Value = "Tống vé bán ra";
                worksheet.Cells[1, 3].Value = "Tổng tiền";

                // Thêm dữ liệu vào Excel
                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].FilmName;
                    worksheet.Cells[i + 2, 2].Value = data[i].TotalTicket;
                    worksheet.Cells[i + 2, 3].Value = data[i].TotalRevenue;
                }

                // Ghi file vào memory và trả về mảng byte
                return package.GetAsByteArray();
            }
        }
    }
}