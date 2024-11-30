using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.About;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class AboutReadOnlyRepository : IAboutReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _dbContext;
        private readonly IMapper _mapper;

        public AboutReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IQueryable<AboutDto>> GetAllAsync()
        {
            var aboutModel = _dbContext.Abouts.AsQueryable();
            if (aboutModel == null)
            {
                return null;
            }
            var aboutDtos = aboutModel.ProjectTo<AboutDto>(_mapper.ConfigurationProvider);
            return aboutDtos;
        }

        public async Task<AboutDto> GetByIdAsync(Guid Id)
        {
            var aboutModel = await _dbContext.Abouts.FirstOrDefaultAsync(x => x.Id == Id);
            if (aboutModel == null)
            {
                return null;
            }
            var aboutDto = _mapper.Map<AboutDto>(aboutModel);
            if (aboutDto != null)
            {
                return aboutDto;
            }
            return null;
        }
    }
}