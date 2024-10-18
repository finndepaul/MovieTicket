using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            CreateMap<Film, FilmDto>()
                .ForMember(dest => dest.ScreenTypeDtos, opt => opt.MapFrom(src => src.FilmScreenTypes.Select(ftt => ftt.ScreenType)))
                .ForMember(dest => dest.TranslationTypeDtos, opt => opt.MapFrom(src => src.FilmTranslationTypes.Select(ftt => ftt.TranslationType)));
            CreateMap<FilmUpdateRequest, Film>().ReverseMap();
            CreateMap<FilmCreateRequest, Film>().ReverseMap();
        }
    }
}