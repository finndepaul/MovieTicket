﻿using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface ICinemaCenterReadOnlyRepository
    {
        Task<IQueryable<CinemaCenterDto>> GetAll(CinemaCenterSearch search);
        Task<ResponseObject<CinemaCenter>> GetById(Guid id);
    }
}
