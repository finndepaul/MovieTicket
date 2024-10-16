using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
	[Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
	[ApiController]
	public class CinemaTypeController : ControllerBase
	{
		private readonly ICinemaTypesReadOnlyRepository _repo;

		public CinemaTypeController(ICinemaTypesReadOnlyRepository repo)
		{
			_repo = repo;
		}

		[HttpGet]
		public async Task<IActionResult> GetListCinemaTypes(CancellationToken cancellationToken)
		{
			var result = await _repo.GetAllAsync();
			return Ok(result);
		}
	}
}
