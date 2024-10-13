using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
	[Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
	[ApiController]
	public class ScreenTypeController : ControllerBase
	{
		private readonly IScreenTypeReadOnlyRepository _screenTypeReadOnly;

		public ScreenTypeController(IScreenTypeReadOnlyRepository screenTypeReadOnly)
		{
			_screenTypeReadOnly = screenTypeReadOnly;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			return Ok(await _screenTypeReadOnly.GetAllAsync());
		}
	}
}
