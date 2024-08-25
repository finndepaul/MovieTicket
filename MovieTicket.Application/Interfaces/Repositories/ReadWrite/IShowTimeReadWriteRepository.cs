using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadWrite
{
    public interface IShowTimeReadWriteRepository
    {
        Task<ResponseObject<ShowTime>> Create(ShowTimeCreateRequest showTime);
        Task<ResponseObject<ShowTime>> Update(Guid Id, ShowTimeUpdateRequest showTime);
        Task<ResponseObject<ShowTime>> Delete(Guid id);
    }
}
