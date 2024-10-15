using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Extensions;

namespace MovieTicket.API.Controllers
{
	[Route(DefaultValue.API_Route.DEFAULT_CONTROLLER_ROUTE)]
	[ApiController]

	public class SeatTypeController : ControllerBase
	{
		private readonly ISeatTypeReadOnlyRepository _repo;

		public SeatTypeController(ISeatTypeReadOnlyRepository repo)
		{
			_repo = repo;
		}
		[HttpGet]
		public async Task<IActionResult> GetListSeatTypes(CancellationToken cancellationToken)
		{
			var result = await _repo.GetAllAsync(cancellationToken);
			return Ok(result);
		}
	}
}
