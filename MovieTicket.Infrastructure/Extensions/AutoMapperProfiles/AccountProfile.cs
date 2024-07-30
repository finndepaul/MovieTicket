using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Extensions.AutoMapperProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountRegisterRequest, Account>().ReverseMap();
        }
    }
}
