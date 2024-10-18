using MovieTicket.Application.DataTransferObjs.Seat;
using MovieTicket.Application.ValueObjs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface ISeatReadOnlyRepository
    {
        Task<IQueryable<SeatDTO>> GetAllAsync(Guid cinemaId);

        Task<ResponseObject<SeatDTO>> GetSeatById(Guid id);
    }
}