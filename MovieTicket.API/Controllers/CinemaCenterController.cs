using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Domain.Entities;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class CinemaCenterController : ControllerBase
    {
        // GET: api/<CinemaCenterController>
        private readonly ICinemaCenterReadOnlyRepository _centerReadOnlyRepository;
        private readonly ICinemaCenterReadWriteRepository _centerReadWriteRepository;
        private readonly IMapper _mapper;

        public CinemaCenterController(ICinemaCenterReadOnlyRepository centerReadOnlyRepository,
                                      ICinemaCenterReadWriteRepository centerReadWriteRepository,
                                      IMapper mapper)
        {
            _centerReadOnlyRepository = centerReadOnlyRepository;
            _centerReadWriteRepository = centerReadWriteRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IQueryable<CinemaCenterDto>> GetAll()
        {
            var cinemaCenterDto = _centerReadOnlyRepository.GetAll();
            return Ok(cinemaCenterDto);
        }

        // GET api/<CinemaCenterController>/5
        [HttpGet]
        public async Task<ActionResult> GetById(Guid id)
        {
            var cinemaCenter = await _centerReadOnlyRepository.GetById(id);
            var cinemaCenterDto = _mapper.Map<CinemaCenterDto>(cinemaCenter);
            if (cinemaCenterDto == null)
            {
                return NotFound();
            }
            return Ok(cinemaCenterDto);
        }

        // POST api/<CinemaCenterController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CinemaCenterCreateRequest cinemaCenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cinemaCenterCreate = _mapper.Map<CinemaCenter>(cinemaCenter);
            await _centerReadWriteRepository.Create(cinemaCenterCreate);
            return Ok(cinemaCenterCreate);
        }

        // PUT api/<CinemaCenterController>/5
        [HttpPut]
        public async Task<ActionResult> Update(Guid id, [FromBody] CinemaCenterUpdateRequest cinemaCenter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cinemaCenterItem = await _centerReadOnlyRepository.GetById(id);
            if (cinemaCenterItem == null)
            {
                return NotFound("Không tìm thấy");
            }
            else
            {
                cinemaCenterItem.Name = cinemaCenter.Name;
                cinemaCenterItem.Address = cinemaCenter.Address;
                await _centerReadWriteRepository.Update(cinemaCenterItem);
                return Ok(cinemaCenterItem);
            }
        }

        // DELETE api/<CinemaCenterController>/5
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var cinemaCenter = await _centerReadOnlyRepository.GetById(id);
            if (cinemaCenter == null)
            {
                return NotFound("Không tìm thấy");
            }
            await _centerReadWriteRepository.Delete(id);
            return Ok("Xóa thành công");
        }
    }
}
