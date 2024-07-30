using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Services.ReadWrite
{
    public interface IRWComboService
    {
        Task<Combo> CreateAsync(Combo combo);
        Task<Combo?> UpdateAsync(Guid id, Combo combo);
        Task<Combo?> DeleteAsync(Guid id);
    }

}
