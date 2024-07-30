using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IRWComboRepository
    {
        Task<Combo> CreateAsync(Combo combo);
        Task<Combo?> UpdateAsync(Guid id, Combo combo);
        Task<Combo?> DeleteAsync(Guid id);
    }

}
