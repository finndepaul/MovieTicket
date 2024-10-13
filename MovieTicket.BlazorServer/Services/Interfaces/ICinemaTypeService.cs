using MovieTicket.Application.DataTransferObjs.CinemaType;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
	public interface ICinemaTypeService
	{
		Task<List<CinemaTypeDto>> GetListCinemaTypesAsync();
	}
}
