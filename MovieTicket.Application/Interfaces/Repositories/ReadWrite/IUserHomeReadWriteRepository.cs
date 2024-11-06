using MovieTicket.Application.DataTransferObjs.UserHome.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IUserHomeReadWriteRepository
    {
        Task<string> CreateCheckAsyc(CreateCheckRequest request, CancellationToken cancellationToken);

        Task<string> UpdateCheckAsyc(UpdateCheckRequest request, CancellationToken cancellationToken);

        Task<string> DeleteCheckAsyc(Guid billId, CancellationToken cancellationToken);
    }
}