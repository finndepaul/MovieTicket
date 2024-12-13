namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface ICloudinaryService
    {
        Task<string> UploadImageAsync(MultipartFormDataContent content);
    }
}
