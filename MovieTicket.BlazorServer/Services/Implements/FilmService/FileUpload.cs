using Microsoft.AspNetCore.Components.Forms;
using MovieTicket.BlazorServer.Services.Interfaces.IFilmService;

namespace MovieTicket.BlazorServer.Services.Implements.FilmService
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public FileUpload(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public bool DeleteFile(string fileName)
        {
            try
            {
                var path = $"{_webHostEnvironment.WebRootPath}\\PosterFilm\\{fileName}";
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            var fileName = $"{Path.GetFileNameWithoutExtension(file.Name)}_{Guid.NewGuid()}{Path.GetExtension(file.Name)}";
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "PosterFilm", fileName);

            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fileStream);
            // Return the relative path
            return Path.Combine("PosterFilm", fileName);
        }
    }
}
