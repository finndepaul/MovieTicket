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
    public class RBillService : IRBillService
    {
        private readonly IRBillRepository repository;

        public RBillService(IRBillRepository repository)
        {
            this.repository = repository;
        }
        public IQueryable<Bill> GetAllAsync()
        {
            return repository.GetAllAsync();
        }

        public IQueryable<Combo?> GetBillByCombo(Guid id)
        {
            return repository.GetBillByCombo(id);
        }

        public async Task<Bill?> GetByIdAsync(Guid Id)
        {
            return await repository.GetByIdAsync(Id);
        }
    }

}
