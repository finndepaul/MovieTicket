using AutoMapper;
using MovieTicket.Application.DataTransferObjs.ScreenType;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class ScreenTypeReadOnlyRepository : IScreenTypeReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _dbContext;
        private readonly IMapper _mapper;

        public ScreenTypeReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IQueryable<ScreenTypeDto>> GetAllAsync()
        {
            var screenTypesModel = _dbContext.ScreenTypes.AsQueryable();
            if (!screenTypesModel.Any()) // Kiểm tra có ít nhát 1 combo không
            {
                throw new InvalidOperationException("No combos found."); // Ném ra ngoại lệ nếu không tìm thấy combo
            }
            var screenTypeDtos = screenTypesModel.Select(s => _mapper.Map<ScreenTypeDto>(s)!); // Ánh xạ từ Combo sang ComboDto
            return screenTypeDtos;
        }
    }
}
