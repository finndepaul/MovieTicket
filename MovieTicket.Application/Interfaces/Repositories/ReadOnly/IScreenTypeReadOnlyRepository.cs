using MovieTicket.Application.DataTransferObjs.ScreenType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IScreenTypeReadOnlyRepository
    {
        Task<IQueryable<ScreenTypeDto>> GetAllAsync();
    }
}
