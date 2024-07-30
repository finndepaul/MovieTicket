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
    public class RWBillService : IRWBillService
    {
        private readonly IRWBillRepository repository;

        public RWBillService(IRWBillRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Bill> CreateAsync(Bill bill, List<Guid> comboId)
        {
            var result = await repository.CreateAsync(bill, comboId);
            return result;
        }

        public async Task<Bill?> DeleteAsync(Guid id)
        {
            var result = await repository.DeleteAsync(id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<Bill?> UpdateAsync(Guid id, Bill bill, List<Guid> comboId)
        {
            var result = await repository.UpdateAsync(id, bill, comboId);
            return result;
        }
    }

}
