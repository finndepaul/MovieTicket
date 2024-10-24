using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Seat;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class SeatProfile : Profile
    {
        public SeatProfile()
        {
            MovieTicketReadOnlyDbContext dbContext = new();

            CreateMap<Seat, SeatDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CinemaId, opt => opt.MapFrom(src => src.CinemaId))
                .ForMember(dest => dest.CinemaCenterName, opt => opt.MapFrom(src => dbContext.CinemaCenters.Find(dbContext.Cinemas.Find(src.CinemaId).CinemaCenterId).Name))
                .ForMember(dest => dest.CinemaName, opt => opt.MapFrom(src => dbContext.Cinemas.Find(src.CinemaId).Name))
                .ForMember(dest => dest.SeatTypeName, opt => opt.MapFrom(src => dbContext.SeatTypes.Find(src.SeatTypeId).Name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ForMember(dest => dest.Row, opt => opt.MapFrom(src => src.Row))
                .ForMember(dest => dest.Column, opt => opt.MapFrom(src => src.Column))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Selection, opt => opt.MapFrom(src => src.Selection));
            CreateMap<SeatUpdateRequest, Seat>().ReverseMap();
            CreateMap<SeatCreateRequest, Seat>().ReverseMap();
        }
    }
}