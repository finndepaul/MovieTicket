using MovieTicket.Application.DataTransferObjs.Cinema;
using MovieTicket.Application.DataTransferObjs.Cinema.Request;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface ICinemaReadWriteRepository
    {
        Task<ResponseObject<CinemaDto>> Create(CinemaCreateRequest request);

        Task<ResponseObject<CinemaDto>> Update(CinemaUpdateRequest request);

        Task<ResponseObject<Cinema>> HardDelete(Guid id);
    }
}