using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class RWComboRepository : IRWComboRepository
    {
        private readonly MovieTicketReadWriteDbContext dbContext;

        public RWComboRepository(MovieTicketReadWriteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Combo> CreateAsync(Combo combo)
        {
            await dbContext.Combos.AddAsync(combo);
            await dbContext.SaveChangesAsync();
            return combo;
        }

        public async Task<Combo?> DeleteAsync(Guid id)
        {
            var result = await dbContext.Combos.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            dbContext.Combos.Remove(result);
            await dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<Combo?> UpdateAsync(Guid id, Combo combo)
        {
            var result = await dbContext.Combos.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            result.Name = combo.Name;
            result.Price = combo.Price;
            await dbContext.SaveChangesAsync();
            return result;
        }
    }

}
