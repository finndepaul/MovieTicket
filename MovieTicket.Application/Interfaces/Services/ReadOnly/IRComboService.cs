using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Services.ReadOnly
{
    public interface IRComboService
    {
        IQueryable<Combo> GetAllAsync();
        Task<Combo?> GetByIdAsync(Guid id);
    }

}
