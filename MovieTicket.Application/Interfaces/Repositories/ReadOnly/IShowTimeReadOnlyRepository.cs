using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IShowTimeReadOnlyRepository
    {
        Task<PageList<ShowTimeDto>> GetAll(ShowTimeSearch? showTimeSearch, PagingParameters pagingParameters);

        Task<ResponseObject<ShowTimeDto>> GetById(Guid id);
    }
}