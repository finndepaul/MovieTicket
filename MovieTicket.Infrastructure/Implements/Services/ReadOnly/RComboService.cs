using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Services.ReadOnly;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Services.ReadOnly
{
    public class RComboService : IRComboService
    {
        private readonly IRComboRepository repository;

        public RComboService(IRComboRepository repository)
        {
            this.repository = repository;
        }
        public IQueryable<Combo> GetAllAsync()
        {
            return repository.GetAllAsync();
        }

        public async Task<Combo?> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }
    }

}
