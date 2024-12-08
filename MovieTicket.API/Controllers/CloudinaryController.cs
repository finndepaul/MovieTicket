using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Cloudinary;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using System.Net;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class CloudinaryController : ControllerBase
    {
        private readonly ICloudinaryReadWriteRepository _cloudinary;

        public CloudinaryController(ICloudinaryReadWriteRepository cloudinary)
        {
            _cloudinary = cloudinary;
        }

        [HttpPost]
        public async Task<ActionResult<UploadImageResponse>> UploadImageAsync(IFormFile formFile)
        {
            var result = await _cloudinary.UploadImageAsync(formFile);
            if (result != null)
            {
                return Ok(new UploadImageResponse { Link = result });
            }
            return Problem("Upload failed", null, (int)HttpStatusCode.InternalServerError);
        }
    }
}
