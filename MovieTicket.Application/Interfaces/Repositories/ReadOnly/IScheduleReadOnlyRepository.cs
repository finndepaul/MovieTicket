﻿using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.DataTransferObjs.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Application.Interfaces.Repositories.ReadOnly
{
    public interface IScheduleReadOnlyRepository
    {
        Task<IQueryable<ScheduleDto>> GetAllAsync();
        Task<ScheduleDto?> GetByIdAsync(Guid id);
        Task<IQueryable<ScheduleDto>> GetByFilmIdAsync(Guid filmId);
    }
}