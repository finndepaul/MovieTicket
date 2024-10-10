using AutoMapper;
using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Domain.Entities;

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