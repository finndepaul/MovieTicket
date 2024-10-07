using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Domain.Enums;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class AccountUtilitiesController : ControllerBase
    {
        private readonly IAccountReadWriteRepository _accountService;
        private readonly IEmailSenderReadWriteRepository _emailService;

        public AccountUtilitiesController(IAccountReadWriteRepository accountService, IEmailSenderReadWriteRepository emailService)
        {
            _accountService = accountService;
            _emailService = emailService;
        }

        [HttpPut]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            await _accountService.ChangePasswordAsync(request, cancellationToken);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            await _accountService.ForgotPasswordAsync(request, cancellationToken);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(string email, EmailType type, CancellationToken cancellationToken)
        {
            var result = await _emailService.SendEmail(email, type, cancellationToken);
            return Ok(result);
        }
    }
}