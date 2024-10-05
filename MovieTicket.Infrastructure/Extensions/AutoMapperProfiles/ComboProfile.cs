using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class ComboProfile : Profile
    {
        public ComboProfile()
        {
            CreateMap<Combo, ComboDto>().ReverseMap();
            CreateMap<CreateComboRequest, Combo>().ReverseMap();
            CreateMap<UpdateComboRequest, Combo>().ReverseMap();
        }
    }
}