using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Domain.Entities;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAccountReadWriteRepository _accountReadWrite;
        private readonly IMapper _mappre;
        public RegisterController(IAccountReadWriteRepository accountReadWrite, IMapper mapper)
        {
            _accountReadWrite = accountReadWrite;
            _mappre = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Register(AccountRegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var register = _mappre.Map<Account>(registerRequest);
            await _accountReadWrite.Register(register);
            return Ok(register);
        }
    }
}
