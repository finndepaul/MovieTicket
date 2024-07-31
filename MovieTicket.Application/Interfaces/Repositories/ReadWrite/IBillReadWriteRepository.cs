using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IBillReadWriteRepository
    {
        Task<BillDto> CreateAsync(CreateBillRequest createBillRequest);
        Task<BillDto?> UpdateAsync(Guid id, UpdateBillRequest updateBillRequest);
        Task<BillDto?> DeleteAsync(Guid id);
    }

}
