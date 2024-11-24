using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Domain.Enums;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ShowTimeController : ControllerBase
    {
        private readonly IShowTimeReadOnlyRepository _readOnly;
        private readonly IShowTimeReadWriteRepository _readWrite;

        public ShowTimeController(IShowTimeReadOnlyRepository readOnly, IShowTimeReadWriteRepository readWrite)
        {
            _readOnly = readOnly;
            _readWrite = readWrite;
        }

        [HttpGet]
        public async Task<ActionResult<ShowTimeDto>> GetAll([FromQuery]ShowTimeSearch? showTimeSearch, [FromQuery] PagingParameters pagingParameters)
        {
            var showTimes = await _readOnly.GetAll(showTimeSearch, pagingParameters);
            var data = showTimes.Item.ToList();
			return Ok(new PageList<ShowTimeDto>(data.ToList(), showTimes.MetaData.TotalCount,
				showTimes.MetaData.CurrentPage,
				showTimes.MetaData.PageSize));
        }

        [HttpGet]
        public async Task<ActionResult<ShowTimeDto>> GetById(Guid id)
        {
            var showTime = await _readOnly.GetById(id);
            return Ok(showTime);
        }

        // POST api/<ShowTimeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ShowTimeCreateRequest showTimeCreate)
        {
            var showTime = await _readWrite.Create(showTimeCreate);
			return Ok(showTime);
		}
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ShowTimeUpdateRequest showTimeUpdate)
        {
            var showTime = await _readWrite.Update(showTimeUpdate);
            return Ok(showTime);
        }
        // DELETE api/<ShowTimeController>/5
        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
			var showTime = await _readWrite.Delete(id);
			return Ok(showTime);
		}
        [HttpPut]
		public async Task<ActionResult> UpdateStatus(ShowTimeUpdateStatus updateStatus)
		{
			var showTime = await _readWrite.UpdateStatus(updateStatus);
			return Ok(showTime);
		}
	}
}