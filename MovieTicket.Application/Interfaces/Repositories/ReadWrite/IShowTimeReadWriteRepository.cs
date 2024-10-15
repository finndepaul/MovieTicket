using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IShowTimeReadWriteRepository
    {
        Task<ResponseObject<ShowTime>> Create(ShowTimeCreateRequest showTime);

        Task<ResponseObject<ShowTime>> Delete(Guid id);
    }
}