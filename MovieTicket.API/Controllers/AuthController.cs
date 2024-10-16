using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Auth.Requests;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Infrastructure.Extensions;
using static MovieTicket.Application.ValueObjs.ViewModels.CustomReponses;

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

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginDTO loginModel, CancellationToken cancellationToken)
        //{
        //    return Ok(await _loginReadWriteRepository.Login(loginModel, cancellationToken));
        //}

        [HttpPost]
        public async Task<ActionResult<LoginRespone>> Login(LoginDTO loginModel)
        {
            var result = await _loginReadWriteRepository.LoginAsync(loginModel);
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<LoginRespone> RefreshToken(UserSession session)
        {
            var result = _loginReadWriteRepository.RefreshToken(session);
            return Ok(result);
        }
    }
}