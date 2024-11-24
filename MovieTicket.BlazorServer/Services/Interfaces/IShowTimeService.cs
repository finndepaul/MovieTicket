using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.BlazorServer.Components.Pages.Admin.ShowTime;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IShowTimeService
    {
        Task<PageList<ShowTimeDto>> GetAll(ShowTimeSearch? showTimeSearch, PagingParameters pagingParameters);

        Task<ResponseObject<ShowTimeDto>> GetById(Guid id);

        Task<ResponseObject<ShowTimeCreateRequest>> Create(ShowTimeCreateRequest showTime);
        Task<ResponseObject<ShowTimeUpdateRequest>> Update(ShowTimeUpdateRequest showTime);
        Task<ResponseObject<ShowTimeDto>> UpdateStatus(ShowTimeUpdateStatus updateStatus);
		Task<ResponseObject<ShowTimeDto>> Delete(Guid id);
    }
}