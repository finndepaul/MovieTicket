using AutoMapper;
using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class CinemaCenterProfile :  Profile
    {
        public CinemaCenterProfile()
        {
            CreateMap<CinemaCenterDto, CinemaCenter>().ReverseMap();
            CreateMap<CinemaCenterCreateRequest, CinemaCenter>();
            CreateMap<CinemaCenterUpdateRequest, CinemaCenter>();
        }

    }
}
