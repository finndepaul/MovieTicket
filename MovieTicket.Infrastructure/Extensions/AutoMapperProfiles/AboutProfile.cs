using AutoMapper;
using MovieTicket.Domain.Entities;
using MovieTicket.Application.DataTransferObjs.About;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<About, AboutDto>().ReverseMap();
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
        }
    }
}
