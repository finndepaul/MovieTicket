using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Services.ReadOnly
{
    public interface IRBillService
    {
        IQueryable<Bill> GetAllAsync();
        Task<Bill?> GetByIdAsync(Guid Id);
        IQueryable<Combo?> GetBillByCombo(Guid id);
    }

}
