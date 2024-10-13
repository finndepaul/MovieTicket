using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Banner;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class BannerProfile : Profile
    {
        public BannerProfile()
        {
            CreateMap<Banner, BannerDTO>().ReverseMap();
            CreateMap<BannerCreateRequest, Banner>().ReverseMap();
            CreateMap<BannerUpdateRequest, Banner>().ReverseMap();
        }
    }
}