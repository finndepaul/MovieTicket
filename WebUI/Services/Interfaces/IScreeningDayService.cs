using MovieTicket.Application.DataTransferObjs.ScreeningDay;

namespace WebUI.Services.Interfaces
{
	public interface IScreeningDayService
	{
		Task<List<ScreeningDayDto>> GetListScreeningDaysAsync();
	}
}
