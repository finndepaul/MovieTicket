using MovieTicket.Application.DataTransferObjs.TranslationType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface ITranslationTypeReadOnlyRepository
    {
        Task<IQueryable<TranslationTypeDto>> GetAllAsync();
    }
}
