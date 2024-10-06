using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
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
		public async Task<ActionResult> GetListRevenueByCinemaAsync([FromQuery]DateTime? startDate, DateTime? endDate)
		{
			var revenueByCinema = await _adminHomeReadOnly.GetListRevenueByCinemaAsync(startDate,endDate);
			return Ok(revenueByCinema);
		}
		[HttpGet]
		public async Task<ActionResult> GetListRevenueByMovieAsync([FromQuery] DateTime? startDate, DateTime? endDate)
		{
			var revenueByMovie = await _adminHomeReadOnly.GetListRevenueByMovieAsync(startDate, endDate);
			return Ok(revenueByMovie);
		}

	}
}
