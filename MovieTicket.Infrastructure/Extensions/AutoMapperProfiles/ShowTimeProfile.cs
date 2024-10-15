using AutoMapper;
using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class ShowTimeProfile : Profile
    {
        public ShowTimeProfile()
        {
            CreateMap<ShowTimeDto, ShowTime>().ReverseMap();
            CreateMap<ShowTimeCreateRequest, ShowTime>();
        }
    }
}