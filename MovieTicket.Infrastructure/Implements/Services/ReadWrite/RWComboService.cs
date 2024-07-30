using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.Interfaces.Services.ReadWrite;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Services.ReadWrite
{
    public class RWComboService : IRWComboService
    {
        private readonly IRWComboRepository repository;

        public RWComboService(IRWComboRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Combo> CreateAsync(Combo combo)
        {
            var result = await repository.CreateAsync(combo);
            return result;
        }

        public async Task<Combo?> DeleteAsync(Guid id)
        {
            var result = await repository.DeleteAsync(id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<Combo?> UpdateAsync(Guid id, Combo combo)
        {
            var result = await repository.UpdateAsync(id, combo);
            return result;
        }
    }

}
