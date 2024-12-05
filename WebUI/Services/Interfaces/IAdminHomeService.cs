using MovieTicket.Application.DataTransferObjs.AdminHome;
using MovieTicket.Application.ValueObjs.Paginations;

namespace WebUI.Services.Interfaces
{
    public interface IAdminHomeService
    {
        Task<PageList<RevenueByCinemaDto>> GetListRevenueByCinemaAsync(DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters);
        Task<PageList<RevenueByMovieDto>> GetListRevenueByMovieAsync(DateTime? startDate, DateTime? endDate, PagingParameters pagingParameters);
        Task<GeneralDto> GetAdminGeneralAsync();
        Task<List<RevenueByMonthDto>> RevenueByMonthDto();
        Task<byte[]> ExportRevenueCinemaDtoToExcel(DateTime? startDate, DateTime? endDate);
        Task<byte[]> ExportRevenueMovieDtoToExcel(DateTime? startDate, DateTime? endDate);
    }
}

