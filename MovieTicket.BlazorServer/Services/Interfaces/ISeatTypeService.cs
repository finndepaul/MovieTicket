using MovieTicket.Application.DataTransferObjs.SeatType;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface ISeatTypeService
    {
        Task<List<SeatTypeDto>> GetListSeatTypesAsync();
    }
}
