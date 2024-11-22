using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.About;
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
    public class AboutReadWriteRepository : IAboutReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _dbContext;
        private readonly IMapper _mapper;

        public AboutReadWriteRepository(MovieTicketReadWriteDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<AboutDto> CreateAsync(CreateAboutDto createAboutDto)
        {
            var aboutModel = _mapper.Map<About>(createAboutDto);
            if(aboutModel == null)
            {
                throw new Exception("Failed to map About");
            }
            await _dbContext.Abouts.AddAsync(aboutModel);
            await _dbContext.SaveChangesAsync();
            var aboutDto = _mapper.Map<AboutDto>(aboutModel);
            if(aboutDto == null)
            {
                throw new Exception("Failed to create About");
            }
            return aboutDto;
        }

        public async Task<AboutDto> DeleteAsync(Guid Id)
        {
            var aboutModel = await _dbContext.Abouts.FirstOrDefaultAsync(x => x.Id == Id);
            if (aboutModel == null)
            {
                throw new Exception("About not found");
            }
            _dbContext.Abouts.Remove(aboutModel);
            await _dbContext.SaveChangesAsync();
            var aboutDto = _mapper.Map<AboutDto>(aboutModel);
            if (aboutDto == null)
            {
                throw new Exception("Failed to delete About");
            }
            return aboutDto;
        }

        public async Task<AboutDto> UpdateAsync(Guid Id, UpdateAboutDto updateAboutDto)
        {
            if (Id == Guid.Empty)
            {
                throw new Exception("Invalid Id");
            }
            if(updateAboutDto == null)
            {
                throw new Exception("Invalid UpdateAboutDto");
            }
            var result = await _dbContext.Abouts.FirstOrDefaultAsync(x => x.Id == Id);
            if (result == null)
            {
                throw new Exception("About not found");
            }
            _mapper.Map(updateAboutDto, result);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<AboutDto>(result);
        }
    }
}
