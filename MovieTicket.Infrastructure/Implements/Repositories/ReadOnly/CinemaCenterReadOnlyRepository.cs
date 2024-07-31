using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
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
        public async Task<IQueryable<CinemaCenterDto>> GetAll()
        { 
            var cinemaCenters = _movieTicket.CinemaCenters.AsNoTracking();//db gọi đến class
            var cinemaCenterDtos = cinemaCenters.ProjectTo<CinemaCenterDto>(_mapper.ConfigurationProvider);//map sang dto
            return cinemaCenterDtos;
        }
        public async Task<CinemaCenter> GetById(Guid id)
        {
            var cinemaCenter = await _movieTicket.CinemaCenters.FindAsync(id);
            if (cinemaCenter == null)
            {
                return null;
            }
            return cinemaCenter;
        }
    }

}
