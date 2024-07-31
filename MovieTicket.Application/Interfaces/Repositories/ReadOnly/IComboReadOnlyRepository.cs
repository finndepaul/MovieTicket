using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IComboReadOnlyRepository
    {
        IQueryable<ComboDto> GetAllAsync();
        Task<ComboDto?> GetByIdAsync(Guid id);
    }

}
