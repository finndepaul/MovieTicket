using MovieTicket.Application.DataTransferObjs.ScreenType;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IScreenTypeService
    {
        Task<List<ScreenTypeDto>> GetAllScreenTypes();
    }
}
