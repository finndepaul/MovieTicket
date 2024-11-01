using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class ComboReadOnlyRepository : IComboReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext dbContext;
        private readonly IMapper mapper;

        public ComboReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IQueryable<ComboDto>> GetAllAsync()
        {
            var comboModel = dbContext.Combos.AsQueryable();
            if(comboModel == null)
            {
                return null;
            }
            var comboDtos = comboModel.ProjectTo<ComboDto>(mapper.ConfigurationProvider);
            return comboDtos;
        }

        public async Task<ComboDto?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid ID.", nameof(id));
            }

            var comboModel = await dbContext.Combos.FirstOrDefaultAsync(x => x.Id == id);
            if (comboModel == null)
            {
                return null;
            }
            var comboDto = mapper.Map<ComboDto>(comboModel);
            return comboDto;
        }
    }
}