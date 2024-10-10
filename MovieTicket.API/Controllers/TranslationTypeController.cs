using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class TranslationTypeController : ControllerBase
    {
        private readonly ITranslationTypeReadOnlyRepository _translationTypeReadOnly;

        public TranslationTypeController(ITranslationTypeReadOnlyRepository translationTypeReadOnly)
        {
            _translationTypeReadOnly = translationTypeReadOnly;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _translationTypeReadOnly.GetAllAsync());
        }
    }
}
