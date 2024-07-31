using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Auth;
using MovieTicket.Application.DataTransferObjs.Auth.Requests;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Infrastructure.Extensions;

namespace MovieTicket.API.Controllers
{
    [Route(DefaultValue.API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginReadWriteRepository _loginReadWriteRepository;

        public AuthController(ILoginReadWriteRepository loginReadWriteRepository)
        {
            _loginReadWriteRepository = loginReadWriteRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            return Ok(await _loginReadWriteRepository.Login(loginRequest, cancellationToken));
        }
    }
}
