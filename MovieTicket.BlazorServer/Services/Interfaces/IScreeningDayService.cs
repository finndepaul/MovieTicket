using MovieTicket.Application.DataTransferObjs.ScreeningDay;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
	public interface IScreeningDayService
	{
		Task<List<ScreeningDayDto>> GetListScreeningDaysAsync();
	}
}
