using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
	[Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
	[ApiController]
	public class TicketController : ControllerBase
	{
		private readonly ITicketReadOnlyRepository _repo;

		public TicketController(ITicketReadOnlyRepository repo)
		{
			_repo = repo;
		}
		[HttpGet]
		public async Task<IActionResult> GetListTicketByBillId(Guid billId, CancellationToken cancellationToken)
		{
			var result = await _repo.GetListTicketByBillId(billId,cancellationToken);
			return Ok(result);
		}
	}
}
