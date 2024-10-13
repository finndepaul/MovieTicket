using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class UserHomeController : ControllerBase
    {
        private readonly IUserHomeReadOnlyRepository _userHomeReadOnly;

        public UserHomeController(IUserHomeReadOnlyRepository userHomeReadOnly)
        {
            _userHomeReadOnly = userHomeReadOnly;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllFilmForUserHome()
        {
            var films = await _userHomeReadOnly.GetAllFilmForUserHome();
            return Ok(films);
        }
    }
}