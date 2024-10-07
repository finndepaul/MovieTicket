using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Film;
using MovieTicket.Domain.Entities;

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