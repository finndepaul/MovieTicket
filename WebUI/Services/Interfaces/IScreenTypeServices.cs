using MovieTicket.Application.DataTransferObjs.ScreenType;

namespace WebUI.Services.Interfaces
{
	public interface IScreenTypeServices
	{
		Task<List<ScreenTypeDto>> GetAllScreenTypes();
	}
}
