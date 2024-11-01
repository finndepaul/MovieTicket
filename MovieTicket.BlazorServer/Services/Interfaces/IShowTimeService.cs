using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IShowTimeService
    {
        Task<PageList<ShowTimeDto>> GetAll(ShowTimeSearch? showTimeSearch, PagingParameters pagingParameters);

        Task<ResponseObject<ShowTimeDto>> GetById(Guid id);

        Task<ResponseObject<ShowTimeCreateRequest>> Create(ShowTimeCreateRequest showTime);

        Task<ResponseObject<ShowTimeDto>> Delete(Guid id);
    }
}