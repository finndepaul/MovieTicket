using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
	public interface ITicketPriceService
	{
		Task<ResponseObject<TicketPriceCreateRequest>> Create(TicketPriceCreateRequest request);
		Task<ResponseObject<bool>> Delete(Guid id);
		Task<ResponseObject<TicketPriceUpdateRequest>> Update(TicketPriceUpdateRequest request);
		Task<PageList<TicketPriceDto>> GetAllAsync(PagingParameters pagingParameters);
		Task<TicketPriceDto> GetByIdAsync(Guid Id);

	}
}
