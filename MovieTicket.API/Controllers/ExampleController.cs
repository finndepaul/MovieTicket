using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;


namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAllExample()
        {
            return Ok();
        }
        [HttpGet]
        public ActionResult GetById()
        {
            return Ok();
        }
        [HttpPost]
        public ActionResult CreateExample()
        {
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateExample()
        {
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteExample()
        {
            return Ok();
        }
    }
}
