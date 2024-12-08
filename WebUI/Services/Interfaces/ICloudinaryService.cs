namespace WebUI.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<string> UploadImageAsync(MultipartFormDataContent content);
    }
}
