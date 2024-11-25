using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Extensions;

namespace MovieTicket.API.Controllers
{
	[Route(DefaultValue.API_Route.DEFAULT_CONTROLLER_ROUTE)]
	[ApiController]
	public class BillComboController : ControllerBase
    {
		private readonly IBillComboReadOnlyRepository _repo;

		public BillComboController(IBillComboReadOnlyRepository repo)
		{
			_repo = repo;
		}
		[HttpGet]
		public async Task<IActionResult> GetListBillComboByBillId(Guid billId,CancellationToken cancellationToken)
		{
			var result = await _repo.GetListBillComboByBillId(billId, cancellationToken);
			return Ok(result);
		}
	}
}
