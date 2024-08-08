using AutoMapper;
using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class TicketPriceProfile : Profile
    {
        public TicketPriceProfile()
        {
            CreateMap<TicketPriceUpdateRequest, TicketPrice>();    
            CreateMap<TicketPriceCreateRequest, TicketPrice>();
            CreateMap<TicketPrice, TicketPriceDto>().ReverseMap();


        }
    }
}
