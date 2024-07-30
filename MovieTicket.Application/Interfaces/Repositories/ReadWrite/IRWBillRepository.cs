using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IRWBillRepository
    {
        Task<Bill> CreateAsync(Bill bill, List<Guid> comboId);
        Task<Bill?> UpdateAsync(Guid id, Bill bill, List<Guid> comboId);
        Task<Bill?> DeleteAsync(Guid id);
    }

}
