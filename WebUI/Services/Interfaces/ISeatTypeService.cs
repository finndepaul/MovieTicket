using MovieTicket.Application.DataTransferObjs.SeatType;

namespace WebUI.Services.Interfaces
{
    public interface ISeatTypeService
    {
        Task<List<SeatTypeDto>> GetListSeatTypesAsync();
    }
}
