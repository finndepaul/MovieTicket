using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.AdminHome;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.Paginations;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
	[Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
	[ApiController]
	public class AdminHomeController : ControllerBase
    {
		private readonly IAdminHomeReadOnlyRepository _adminHomeReadOnly;

		public AdminHomeController(IAdminHomeReadOnlyRepository adminHomeReadOnly)
		{
			_adminHomeReadOnly = adminHomeReadOnly;
		}

		[HttpGet]
		public async Task<ActionResult> GetAdminGeneralAsync()
		{
			var general = await _adminHomeReadOnly.GetAdminGeneralAsync();
			return Ok(general);
		}
		[HttpGet]
		public async Task<ActionResult> GetListRevenueByCinemaAsync([FromQuery]DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] PagingParameters pagingParameters)
		{
			var revenueByCinema = await _adminHomeReadOnly.GetListRevenueByCinemaAsync(startDate,endDate,pagingParameters);
			var data = revenueByCinema.Item.ToList();
			return Ok(new PageList<RevenueByCinemaDto>(data.ToList(), revenueByCinema.MetaData.TotalCount,
				revenueByCinema.MetaData.CurrentPage,
				revenueByCinema.MetaData.PageSize));
		}
		[HttpGet]
		public async Task<ActionResult> GetListRevenueByMovieAsync([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] PagingParameters pagingParameters)
		{
			var revenueByMovie = await _adminHomeReadOnly.GetListRevenueByMovieAsync(startDate, endDate, pagingParameters);
			var data = revenueByMovie.Item.ToList();
			return Ok(new PageList<RevenueByMovieDto>(data.ToList(),
				revenueByMovie.MetaData.TotalCount,
				revenueByMovie.MetaData.CurrentPage,
				revenueByMovie.MetaData.PageSize));
		}
        [HttpGet]
        public async Task<ActionResult> RevenueByMonthDto()
        {
            var revenueByMonth = await _adminHomeReadOnly.GetTopRevenueMonth();
            return Ok(revenueByMonth);
        }
		[HttpGet]
		public async Task<ActionResult> ExportRevenueCinemaDtoToExcel([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
		{
			var file = await _adminHomeReadOnly.ExportRevenueCinemaDtoToExcel(startDate, endDate);
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RevenueByCinema.xlsx");
        }
        [HttpGet]
        public async Task<ActionResult> ExportRevenueMovieDtoToExcel([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var file = await _adminHomeReadOnly.ExportRevenueMovieDtoToExcel(startDate, endDate);
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RevenueByMovie.xlsx");
        }
    }
}
