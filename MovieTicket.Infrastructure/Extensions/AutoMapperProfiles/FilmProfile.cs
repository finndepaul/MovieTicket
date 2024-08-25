using AutoMapper;
using MovieTicket.Domain.Entities;
using MovieTicket.Application.DataTransferObjs.Film;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            CreateMap<Film, FilmDto>().ReverseMap();
            CreateMap<FilmUpdateRequest, Film>().ReverseMap();
            CreateMap<FilmCreateRequest, Film>().ReverseMap();
        }
    }
}
