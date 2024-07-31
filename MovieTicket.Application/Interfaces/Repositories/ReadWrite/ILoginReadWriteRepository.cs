using MovieTicket.Application.DataTransferObjs.Auth;
using MovieTicket.Application.DataTransferObjs.Auth.Requests;
using MovieTicket.Application.ValueObjs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface ILoginReadWriteRepository
    {
        Task<ResponseObject<LoginDto>> Login(LoginRequest loginRequest, CancellationToken cancellationToken);
    }
}
