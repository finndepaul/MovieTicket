using AutoMapper;
using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class CinemaCenterProfile : Profile
    {
        public CinemaCenterProfile()
        {
            CreateMap<CinemaCenterDto, CinemaCenter>().ReverseMap();
            CreateMap<CinemaCenterCreateRequest, CinemaCenter>();
            CreateMap<CinemaCenterUpdateRequest, CinemaCenter>();
        }
    }
}