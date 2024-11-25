using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.About;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class AboutController : Controller
    {
        private readonly IAboutReadOnlyRepository _aboutReadOnly;
        private readonly IAboutReadWriteRepository _aboutReadWrite;

        public AboutController(IAboutReadOnlyRepository aboutReadOnly, IAboutReadWriteRepository aboutReadWrite)
        {
            _aboutReadOnly = aboutReadOnly;
            _aboutReadWrite = aboutReadWrite;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var abouts = await _aboutReadOnly.GetAllAsync();
            if (abouts == null)
            {
                return NotFound();
            }
            return Ok(abouts);
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(Guid Id)
        {
            var about = await _aboutReadOnly.GetByIdAsync(Id);
            if (about == null)
            {
                return NotFound();
            }
            return Ok(about);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateAboutDto createAboutDto)
        {
            var about = await _aboutReadWrite.CreateAsync(createAboutDto);
            if (about == null)
            {
                return BadRequest();
            }
            return Ok(about);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Guid Id, UpdateAboutDto updateAboutDto)
        {
            var about = await _aboutReadWrite.UpdateAsync(Id, updateAboutDto);
            if (about == null)
            {
                return BadRequest();
            }
            return Ok(about);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var about = await _aboutReadWrite.DeleteAsync(Id);
            if (about == null)
            {
                return BadRequest();
            }
            return Ok(about);
        }
    }
}
