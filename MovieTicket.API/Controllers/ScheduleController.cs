using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Coupon;
using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.Application.DataTransferObjs.Schedule.Request;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Infrastructure.Implements.Repositories.ReadOnly;
using System.Threading;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleReadWriteRepository _scheduleReadWriteRepository;
        private readonly IScheduleReadOnlyRepository _scheduleReadOnlyRepository;

        public ScheduleController(IScheduleReadWriteRepository scheduleReadWriteRepository, IScheduleReadOnlyRepository scheduleReadOnlyRepository)
        {
            this._scheduleReadWriteRepository = scheduleReadWriteRepository;
            this._scheduleReadOnlyRepository = scheduleReadOnlyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaging([FromQuery] string? filmName, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] PagingParameters pagingParameters, CancellationToken cancellationToken)
        {
            var result = await _scheduleReadOnlyRepository.GetAllPagingAsync(filmName, startDate, endDate, pagingParameters, cancellationToken);
            return Ok(new PageList<ScheduleDto>(result.Item.ToList(), result.MetaData.TotalCount,
                result.MetaData.CurrentPage,
                result.MetaData.PageSize));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _scheduleReadOnlyRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _scheduleReadOnlyRepository.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetFilmWithoutScheduel()
        {
            var result = await _scheduleReadOnlyRepository.GetFilmForCreateAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateScheduleRequest createScheduleRequest, CancellationToken cancellationToken)
        {
            var result = await _scheduleReadWriteRepository.CreateAsync(createScheduleRequest, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateScheduleRequest updateScheduleRequest, CancellationToken cancellationToken)
        {
            var result = await _scheduleReadWriteRepository.UpdateAsync(updateScheduleRequest, cancellationToken);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _scheduleReadWriteRepository.DeleteAsync(id, cancellationToken);
            return Ok(result);
        }
    }
}