using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.UserHome.Requests;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
	[Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
	[ApiController]
	public class UserHomeController : ControllerBase
	{
		private readonly IUserHomeReadOnlyRepository _userHomeReadOnly;
		private readonly IUserHomeReadWriteRepository _userHomeReadWrite;

		public UserHomeController(IUserHomeReadOnlyRepository userHomeReadOnly, IUserHomeReadWriteRepository userHomeReadWrite)
		{
			_userHomeReadOnly = userHomeReadOnly;
			_userHomeReadWrite = userHomeReadWrite;
		}

		[HttpGet]
		public async Task<ActionResult> GetAllFilmForUserHome()
		{
			var films = await _userHomeReadOnly.GetAllFilmForUserHome();
			return Ok(films);
		}

		[HttpPost]
		public async Task<ActionResult> CreateCheck(CreateCheckRequest request, CancellationToken cancellationToken)
		{
			var model = await _userHomeReadWrite.CreateCheckAsync(request, cancellationToken);
			return Ok(model);
		}

		[HttpPut]
		public async Task<ActionResult> AddComboToCheck(ComboCheckRequest request, CancellationToken cancellationToken)
		{
			var model = await _userHomeReadWrite.AddComboToCheckAsync(request, cancellationToken);
			return Ok(model);
		}

		[HttpPut]
		public async Task<ActionResult> AddDiscountToCheck(DiscountCheckRequest request, CancellationToken cancellationToken)
		{
			var model = await _userHomeReadWrite.AddDiscountToCheckAsync(request, cancellationToken);
			return Ok(model);
		}

		[HttpGet]
		public async Task<ActionResult> GetPointOfMembership(Guid accountId, CancellationToken cancellationToken)
		{
			var model = await _userHomeReadOnly.GetPointOfMembershipAsync(accountId, cancellationToken);
			return Ok(model);
		}

		[HttpPut]
		public async Task<ActionResult> CheckOutSuccess(CheckOutSuccessRequest request, CancellationToken cancellationToken)
		{
			var model = await _userHomeReadWrite.CheckOutSuccessAsync(request, cancellationToken);
			return Ok(model);
		}

		[HttpDelete]
		public async Task<ActionResult> DeleteCheck(Guid billId, CancellationToken cancellationToken)
		{
			var model = await _userHomeReadWrite.DeleteCheckAsync(billId, cancellationToken);
			return Ok(model);
		}
	}
}