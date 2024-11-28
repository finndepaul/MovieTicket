using MovieTicket.Application.DataTransferObjs.BillCombo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IBillComboReadOnlyRepository
    {
        Task<IQueryable<BillComboDto>> GetListBillComboByBillId(Guid billId, CancellationToken cancellationToken);
    }
}
