using MovieTicket.Application.DataTransferObjs.Seat;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace WebUI.Services.Interfaces
{
    public interface ISeatService
    {
        Task<IQueryable<SeatDTO>> GetSeats(Guid cinemaId);

        Task<ResponseObject<SeatDTO>> GetById(Guid id);

        Task<ResponseObject<SeatDTO>> Create(SeatCreateRequest request);

        Task<ResponseObject<SeatDTO>> Update(SeatUpdateRequest request);

        Task<ResponseObject<SeatDTO>> Delete(Guid id);

        Task<ResponseObject<List<SeatDTO>>> UpdateRange(List<SeatUpdateRequest> request);
    }
}