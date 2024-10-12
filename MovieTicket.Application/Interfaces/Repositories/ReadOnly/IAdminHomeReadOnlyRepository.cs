using MovieTicket.Application.DataTransferObjs.AdminHome;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IAdminHomeReadOnlyRepository
    {
        Task<GeneralDto> GetAdminGeneralAsync();

        Task<IQueryable<RevenueByCinemaDto>> GetListRevenueByCinemaAsync(DateTime? startDate, DateTime? endDate);

        Task<IQueryable<RevenueByMovieDto>> GetListRevenueByMovieAsync(DateTime? startDate, DateTime? endDate);
    }
}