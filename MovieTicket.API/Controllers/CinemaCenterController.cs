using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class CinemaCenterController : ControllerBase
    {
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
        public async Task<IActionResult> GetAll([FromQuery] CinemaCenterSearch search)
        {
            var cinemaCenterDto = await _centerReadOnlyRepository.GetAll(search);
            return Ok(cinemaCenterDto);
        }
		[HttpGet]
		public async Task<ActionResult<CinemaCenterDto>> GetAllCinemaCenter([FromQuery] CinemaCenterSearch search, [FromQuery] PagingParameters pagingParameters)
		{
			var cinemaCenterDto = await _centerReadOnlyRepository.GetAllCinemaCenter(search, pagingParameters);
            var data = cinemaCenterDto.Item.ToList();
			return Ok(new PageList<CinemaCenterDto>(data.ToList(), cinemaCenterDto.MetaData.TotalCount,
				cinemaCenterDto.MetaData.CurrentPage,
				cinemaCenterDto.MetaData.PageSize));
		}
		[HttpGet]
        public async Task<ActionResult> GetById(Guid id)
        {
            var cinemaCenter = await _centerReadOnlyRepository.GetById(id);
            return Ok(cinemaCenter);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CinemaCenterCreateRequest cinemaCenter)
        {
            var cinemaCenterCreate = _mapper.Map<CinemaCenter>(cinemaCenter);
            var check = await _centerReadWriteRepository.Create(cinemaCenterCreate);
            return Ok(check);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Guid id, [FromBody] CinemaCenterUpdateRequest cinemaCenter)
        {
            var check = await _centerReadWriteRepository.Update(id, cinemaCenter);
            return Ok(check);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _centerReadWriteRepository.Delete(id);
            return Ok(result);
        }
    }
}