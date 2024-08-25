using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.ValueObjs.ViewModels;
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
        Task<ResponseObject<BillDto>> CreateAsync(CreateBillRequest createBillRequest);
        Task<ResponseObject<BillDto>?> UpdateAsync(Guid id, UpdateBillRequest updateBillRequest);
        Task<ResponseObject<BillDto>?> DeleteAsync(Guid id);
    }

}
