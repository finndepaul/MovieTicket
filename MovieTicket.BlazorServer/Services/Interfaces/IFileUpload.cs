using Microsoft.AspNetCore.Components.Forms;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);

        bool DeleteFile(string fileName);
    }
}
