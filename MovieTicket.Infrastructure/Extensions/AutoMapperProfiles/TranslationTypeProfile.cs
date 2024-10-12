using AutoMapper;
using MovieTicket.Application.DataTransferObjs.TranslationType;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class TranslationTypeProfile : Profile
    {
        public TranslationTypeProfile()
        {
            CreateMap<TranslationType, TranslationTypeDto>().ReverseMap();
        }
    }
}
