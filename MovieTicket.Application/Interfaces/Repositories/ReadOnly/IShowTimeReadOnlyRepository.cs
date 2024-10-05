using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IShowTimeReadOnlyRepository
    {
        Task<IQueryable<ShowTimeDto>> GetAll(string? name);

        Task<ResponseObject<ShowTimeDto>> GetById(Guid id);
    }
}