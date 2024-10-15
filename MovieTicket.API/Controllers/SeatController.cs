using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Seat;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatReadOnlyRepository _seatReadOnlyRepository;
        private readonly ISeatReadWriteRepository _seatReadWriteRepository;
        private readonly IMapper _mapper;

        public SeatController(ISeatReadOnlyRepository seatReadOnlyRepository, ISeatReadWriteRepository seatReadWriteRepository)
        {
            _seatReadOnlyRepository = seatReadOnlyRepository;
            _seatReadWriteRepository = seatReadWriteRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(Guid CinemaId)
        {
            var seatDto = await _seatReadOnlyRepository.GetAllAsync(CinemaId);
            return Ok(seatDto);
        }

        [HttpGet]
        public async Task<ActionResult> GetById(Guid id)
        {
            var seat = await _seatReadOnlyRepository.GetSeatById(id);
            return Ok(seat);
        }

        [HttpPost]
        public async Task<ActionResult> Create(SeatCreateRequest request, string position)
        {
            var create = await _seatReadWriteRepository.CreateAsync(request, position);
            return Ok(create);
        }

        [HttpPut]
        public async Task<ActionResult> Update(SeatUpdateRequest request)
        {
            var update = await _seatReadWriteRepository.UpdateAsync(request);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult> HardDelete(Guid id)
        {
            var delete = await _seatReadWriteRepository.HardDelete(id);
            return Ok(delete);
        }
    }
}