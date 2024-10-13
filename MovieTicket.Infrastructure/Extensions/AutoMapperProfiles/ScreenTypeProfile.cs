using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.ScreenType;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class ScreenTypeProfile : Profile
    {
        public ScreenTypeProfile() 
        {
            CreateMap<ScreenType, ScreenTypeDto>().ReverseMap();
        }
    }
}