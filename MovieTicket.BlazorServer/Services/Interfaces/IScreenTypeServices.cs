using MovieTicket.Application.DataTransferObjs.ScreenType;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
	public interface IScreenTypeServices
	{
		Task<List<ScreenTypeDto>> GetAllScreenTypes();
	}
}
