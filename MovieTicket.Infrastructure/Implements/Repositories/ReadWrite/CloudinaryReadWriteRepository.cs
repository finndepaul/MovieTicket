using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class CloudinaryReadWriteRepository : ICloudinaryReadWriteRepository
    {
        public readonly IConfiguration _configuration;
        public readonly Account account;
        public CloudinaryReadWriteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            account = new Account(
                configuration.GetSection("Cloudinary")["CloudName"],
                configuration.GetSection("Cloudinary")["ApiKey"],
                configuration.GetSection("Cloudinary")["ApiSecret"]
            );
        }
        public async Task<string> UploadImageAsync(IFormFile formFile)
        {
            var client = new Cloudinary(account);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(formFile.FileName, formFile.OpenReadStream()),
                DisplayName = formFile.FileName
            };

            var uploadResult = await client.UploadAsync(uploadParams);

            if (uploadResult != null && uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.SecureUri.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
