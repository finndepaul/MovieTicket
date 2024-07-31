using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
