using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class RComboRepository : IRComboRepository
    {
        private readonly MovieTicketReadOnlyDbContext dbContext;

        public RComboRepository(MovieTicketReadOnlyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<Combo> GetAllAsync()
        {
            var result = dbContext.Combos.AsQueryable();
            return result;
        }

        public async Task<Combo?> GetByIdAsync(Guid id)
        {
            var result = await dbContext.Combos.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }

}
