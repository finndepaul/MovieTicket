using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Seat;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class SeatProfile : Profile
    {
        public SeatProfile()
        {
            CreateMap<Seat, SeatDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CinemaId, opt => opt.MapFrom(src => src.CinemaId))
                .ForMember(dest => dest.CinemaCenterName, opt => opt.MapFrom(src => src.Cinema.CinemaCenter.Name))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => src.Cinema.Name))
                .ForMember(dest => dest.SeatTypeName, opt => opt.MapFrom(src => src.SeatType.Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
            CreateMap<SeatUpdateRequest, Seat>().ReverseMap();
            CreateMap<SeatCreateRequest, Seat>().ReverseMap();
        }
    }
}