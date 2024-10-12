using MovieTicket.Application.DataTransferObjs.ScreenType;

namespace MovieTicket.BlazorServer.Services.Interfaces.IScreenTypeService
{
    public interface IScreenTypeService
    {
        Task<List<ScreenTypeDto>> GetAllScreenTypes();
    }
}
