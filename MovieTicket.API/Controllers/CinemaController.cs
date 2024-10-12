using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Cinema;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaReadOnlyRepository _cinemaReadOnlyRepository;

        public CinemaController(ICinemaReadOnlyRepository cinemaReadOnlyRepository)
        {
            _cinemaReadOnlyRepository = cinemaReadOnlyRepository;
        }

        [HttpGet]
        public ActionResult<IQueryable<CinemaDto>> GetAll()
        {
            var cinemaDto = _cinemaReadOnlyRepository.GetAllAsync();
            return Ok(cinemaDto);
        }

        [HttpGet]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var cinema = await _cinemaReadOnlyRepository.GetCinemaById(id, cancellationToken);
            return Ok(cinema);
        }
    }
}
