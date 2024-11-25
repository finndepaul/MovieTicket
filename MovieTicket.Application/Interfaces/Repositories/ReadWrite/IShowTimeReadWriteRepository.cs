using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IShowTimeReadWriteRepository
    {
        Task<ResponseObject<ShowTime>> Create(ShowTimeCreateRequest showTime);

        Task<ResponseObject<ShowTime>> Update(ShowTimeUpdateRequest showTime);
        Task<ResponseObject<ShowTime>> Delete(Guid id);
        Task<ResponseObject<ShowTime>> UpdateStatus(ShowTimeUpdateStatus updateStatus);
	}
}