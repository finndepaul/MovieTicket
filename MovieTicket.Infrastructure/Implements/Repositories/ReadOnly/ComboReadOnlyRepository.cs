using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

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

        public IQueryable<ComboDto> GetAllAsync()
        {
            var comboModel = dbContext.Combos.AsQueryable();
            if (!comboModel.Any()) // Kiểm tra có ít nhát 1 combo không
            {
                throw new InvalidOperationException("No combos found."); // Ném ra ngoại lệ nếu không tìm thấy combo
            }
            var comboDtos = comboModel.Select(combo => mapper.Map<ComboDto>(combo)!); // Ánh xạ từ Combo sang ComboDto
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
