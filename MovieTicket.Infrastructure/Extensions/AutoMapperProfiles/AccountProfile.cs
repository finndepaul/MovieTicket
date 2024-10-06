using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Domain.Entities;

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