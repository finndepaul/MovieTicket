using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IComboReadWriteRepository
    {
        Task<ComboDto> CreateAsync(CreateComboRequest addComboRequest);
        Task<ComboDto?> UpdateAsync(Guid id, UpdateComboRequest updateComboRequest);
        Task<ComboDto?> DeleteAsync(Guid id);
    }

}
