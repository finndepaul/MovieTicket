using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Extensions;

namespace MovieTicket.API.Controllers
{
	[Route(DefaultValue.API_Route.DEFAULT_CONTROLLER_ROUTE)]
	[ApiController]

	public class ScreeningDayController : ControllerBase
	{
		private readonly IScreeningDayReadOnlyRepository _repo;

		public ScreeningDayController(IScreeningDayReadOnlyRepository screeningDayReadOnlyRepository)
		{
			_repo = screeningDayReadOnlyRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetListScreeningDays(CancellationToken cancellationToken)
		{
			var result = await _repo.GetAllAsync(cancellationToken);
			return Ok(result);
		}
	}
}
