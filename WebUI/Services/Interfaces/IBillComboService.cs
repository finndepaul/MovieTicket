using MovieTicket.Application.DataTransferObjs.BillCombo;

namespace WebUI.Services.Interfaces
{
	public interface IBillComboService
	{
		Task<List<BillComboDto>> GetListBillComboByBillId(Guid billId);

	}
}
