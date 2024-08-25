using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Infrastructure.Implements.Repositories.ReadOnly;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleReadWriteRepository scheduleReadWriteRepository;
        private readonly IScheduleReadOnlyRepository scheduleReadOnlyRepository;

        public ScheduleController(IScheduleReadWriteRepository scheduleReadWriteRepository, IScheduleReadOnlyRepository scheduleReadOnlyRepository)
        {
            this.scheduleReadWriteRepository = scheduleReadWriteRepository;
            this.scheduleReadOnlyRepository = scheduleReadOnlyRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await scheduleReadOnlyRepository.GetAllAsync();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await scheduleReadOnlyRepository.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetByFilmId(Guid filmId)
        {
            var result = await scheduleReadOnlyRepository.GetByFilmIdAsync(filmId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateScheduleRequest createScheduleRequest)
        {
            var result = await scheduleReadWriteRepository.CreateAsync(createScheduleRequest);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateScheduleRequest updateScheduleRequest)
        {
            var result = await scheduleReadWriteRepository.UpdateAsync(id, updateScheduleRequest);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await scheduleReadWriteRepository.DeleteAsync(id);
            return Ok(result);
        }
    }
}
