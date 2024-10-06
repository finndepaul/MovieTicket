using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Domain.Entities;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            CreateMap<Bill, BillDto>().ReverseMap();
            CreateMap<CreateBillRequest, Bill>().ReverseMap();
            CreateMap<UpdateBillRequest, Bill>().ReverseMap();
        }
    }
}