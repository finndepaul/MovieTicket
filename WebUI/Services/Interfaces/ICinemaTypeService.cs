using MovieTicket.Application.DataTransferObjs.CinemaType;

namespace WebUI.Services.Interfaces
{
	public interface ICinemaTypeService
	{
		Task<List<CinemaTypeDto>> GetListCinemaTypesAsync();
	}
}
