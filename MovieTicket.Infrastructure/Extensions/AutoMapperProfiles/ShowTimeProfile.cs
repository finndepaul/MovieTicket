using AutoMapper;
using MovieTicket.Application.DataTransferObjs.ShowTime;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class ShowTimeProfile : Profile
    {
        public ShowTimeProfile()
        {
            CreateMap<ShowTimeDto,ShowTime>().ReverseMap();
            CreateMap<ShowTimeCreateRequest, ShowTime>();
            CreateMap<ShowTimeUpdateRequest, ShowTime>();
        }
    }
}
