using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IBillReadOnlyRepository
    {
        Task<IQueryable<BillDto>> GetAllAsync();
        Task<BillDtoGetById?> GetByIdAsync(Guid Id);
    }

}
