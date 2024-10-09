using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.Application.DataTransferObjs.Schedule.Request;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, ScheduleDto>().ReverseMap();
            CreateMap<CreateScheduleRequest, Schedule>().ReverseMap();
            CreateMap<UpdateScheduleRequest, Schedule>().ReverseMap();
        }
    }
}
