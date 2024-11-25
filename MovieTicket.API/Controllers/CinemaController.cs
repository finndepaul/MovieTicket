using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Cinema;
using MovieTicket.Application.DataTransferObjs.Cinema.Request;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaReadOnlyRepository _cinemaReadOnlyRepository;
        private readonly ICinemaReadWriteRepository _cinemaReadWriteRepository;
        private readonly IMapper _mapper;

        public CinemaController(ICinemaReadOnlyRepository cinemaReadOnlyRepository, ICinemaReadWriteRepository cinemaReadWriteRepository)
        {
            _cinemaReadOnlyRepository = cinemaReadOnlyRepository;
            _cinemaReadWriteRepository = cinemaReadWriteRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(string? cinemaCenterName)
        {
            var cinemaDto = await _cinemaReadOnlyRepository.GetAllAsync(cinemaCenterName);
            return Ok(cinemaDto);
        } 
        [HttpGet]
        public async Task<ActionResult> GetAllCinema()
        {
            var cinemaDto = await _cinemaReadOnlyRepository.GetAll();
            return Ok(cinemaDto);
        }

        [HttpGet]
        public async Task<ActionResult> GetById(Guid id)
        {
            var cinema = await _cinemaReadOnlyRepository.GetCinemaById(id);
            return Ok(cinema);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CinemaCreateRequest request)
        {
            var create = await _cinemaReadWriteRepository.Create(request);
            return Ok(create);
        }

        [HttpPut]
        public async Task<ActionResult> Update(CinemaUpdateRequest request)
        {
            var update = await _cinemaReadWriteRepository.Update(request);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult> HardDelete(Guid id)
        {
            var delete = await _cinemaReadWriteRepository.HardDelete(id);
            return Ok(delete);
        }
    }
}