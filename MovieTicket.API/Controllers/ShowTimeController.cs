using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
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
        public ActionResult<IQueryable<ShowTimeDto>> GetAll(string? name)
        {
            var showTimes = _readOnly.GetAll(name);
            return Ok(showTimes);
        }

        [HttpGet]
        public async Task<ActionResult<ShowTimeDto>> GetById(Guid id)
        {
            var showTime = await _readOnly.GetById(id);
            return Ok(showTime);
        }

        // POST api/<ShowTimeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ShowTimeController>/5
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShowTimeController>/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
