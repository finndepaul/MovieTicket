using MovieTicket.Application.DataTransferObjs.BillCombo;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
	public interface IBillComboService
	{
		Task<List<BillComboDto>> GetListBillComboByBillId(Guid billId);

	}
}
