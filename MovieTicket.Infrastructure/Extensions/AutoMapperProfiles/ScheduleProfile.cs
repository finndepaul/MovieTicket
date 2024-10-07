using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Schedule;
using MovieTicket.Domain.Entities;

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