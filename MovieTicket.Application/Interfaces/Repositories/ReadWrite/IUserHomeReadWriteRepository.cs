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
        Task<string> CreateCheckAsync(CreateCheckRequest request, CancellationToken cancellationToken);

        Task<string> UpdateCheckAsync(UpdateCheckRequest request, CancellationToken cancellationToken);

        Task<string> DeleteCheckAsync(Guid billId, CancellationToken cancellationToken);

        Task<string> CheckOutSuccessAsync(Guid billId, CancellationToken cancellationToken);
    }
}