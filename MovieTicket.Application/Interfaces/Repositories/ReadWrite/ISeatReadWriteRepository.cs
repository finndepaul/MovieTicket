using MovieTicket.Application.DataTransferObjs.Seat;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface ISeatReadWriteRepository
    {
        Task<ResponseObject<SeatDTO>> CreateAsync(SeatCreateRequest request, string position);

        Task<ResponseObject<SeatDTO>> UpdateAsync(SeatUpdateRequest request);

        Task<ResponseObject<Seat>> HardDelete(Guid id);
    }
}