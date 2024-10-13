using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.ScreenType;
using MovieTicket.Application.DataTransferObjs.TranslationType;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class TranslationTypeReadOnlyRepository : ITranslationTypeReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext dbContext;
        private readonly IMapper mapper;

        public TranslationTypeReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<TranslationTypeDto>> GetAllAsync()
        {
            var translationTypeModel = dbContext.TranslationTypes.AsQueryable();
            if (!translationTypeModel.Any()) // Kiểm tra có ít nhát 1 combo không
            {
                throw new InvalidOperationException("No combos found."); // Ném ra ngoại lệ nếu không tìm thấy combo
            }
            var translationTypeDto = translationTypeModel.Select(t => mapper.Map<TranslationTypeDto>(t)!); // Ánh xạ từ Combo sang ComboDto
            return translationTypeDto;
        }
    }
}
