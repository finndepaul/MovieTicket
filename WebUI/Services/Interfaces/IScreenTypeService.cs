using MovieTicket.Application.DataTransferObjs.ScreenType;

namespace WebUI.Services.Interfaces
{
    public interface IScreenTypeService
    {
        Task<List<ScreenTypeDto>> GetAllScreenTypes();
    }
}
