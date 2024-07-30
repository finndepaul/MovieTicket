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
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Combo, ComboDTOs>().ReverseMap();
            CreateMap<AddComboRequestDTOs, Combo>().ReverseMap();
            CreateMap<UpdateComboRequestDTOs, Combo>().ReverseMap();

            CreateMap<Bill, BillDTOs>().ReverseMap();
            CreateMap<AddBillRequestDTOs, Bill>().ReverseMap();
            CreateMap<UpdateBillRequestDTOs, Bill>().ReverseMap();
        }
    }

}
