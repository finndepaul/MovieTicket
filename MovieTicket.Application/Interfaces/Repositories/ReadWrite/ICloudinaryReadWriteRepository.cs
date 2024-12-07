using Microsoft.AspNetCore.Http;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface ICloudinaryReadWriteRepository
    {
        Task<string> UploadImageAsync(IFormFile formFile);
    }
}
