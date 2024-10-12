using MovieTicket.Application.DataTransferObjs.AdminHome;
using MovieTicket.Application.ValueObjs.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
	public interface IAdminHomeReadOnlyRepository
	{
		Task<GeneralDto> GetAdminGeneralAsync();
		Task<PageList<RevenueByCinemaDto>> GetListRevenueByCinemaAsync(DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters);
		Task<PageList<RevenueByMovieDto>> GetListRevenueByMovieAsync(DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters);
		Task <IQueryable<RevenueByMonthDto>> GetTopRevenueMonth();
		Task<byte[]> ExportRevenueCinemaDtoToExcel(DateTime? startDate, DateTime? endDate);
        Task<byte[]> ExportRevenueMovieDtoToExcel(DateTime? startDate, DateTime? endDate);
    }
}
