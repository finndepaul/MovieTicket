using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class CinemaCenterReadOnlyRepository : ICinemaCenterReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _movieTicket;
        private readonly IMapper _mapper;
        public CinemaCenterReadOnlyRepository(MovieTicketReadOnlyDbContext movieTicket, IMapper mapper)
        {
            _movieTicket = movieTicket;
            _mapper = mapper;
        }
        public async Task<IQueryable<CinemaCenterDto>> GetAll(CinemaCenterSearch search)
        { 
            var cinemaCenters = _movieTicket.CinemaCenters.AsQueryable();//db gọi đến class
            if (!string.IsNullOrEmpty(search.Name))
            {
                cinemaCenters = cinemaCenters.Where(x => x.Name.Contains(search.Name));// lọc theo tên
            }
            if (!string.IsNullOrEmpty(search.Address))
            {
                cinemaCenters = cinemaCenters.Where(x => x.Address.Contains(search.Address));// lọc theo địa chỉ
            }
            var cinemaCenterDtos = cinemaCenters.ProjectTo<CinemaCenterDto>(_mapper.ConfigurationProvider);//map sang dto
            return cinemaCenterDtos;
        }
        public async Task<ResponseObject<CinemaCenter>> GetById(Guid id)
        {
            var cinemaCenter = await _movieTicket.CinemaCenters.FindAsync(id);
            if (cinemaCenter == null)
            {
                return new ResponseObject<CinemaCenter>
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Cinema Center not found",
                    Data = null
                };
            }
            return new ResponseObject<CinemaCenter> 
            {
                Data = cinemaCenter,
                Status = StatusCodes.Status200OK,
                Message = "Get Cinema Center success"
            };
        }
    }

}
