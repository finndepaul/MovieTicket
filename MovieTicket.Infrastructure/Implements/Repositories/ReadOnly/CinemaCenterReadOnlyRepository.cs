using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        public IQueryable<CinemaCenterDto> GetAll()
        {
            var cinemaCenters = _movieTicket.CinemaCenters;
            var cinemaCenterDtos = cinemaCenters.ProjectTo<CinemaCenterDto>(_mapper.ConfigurationProvider);
            return cinemaCenterDtos;
        }
        public async Task<CinemaCenter> GetById(Guid id)
        {
            var cinemaCenter = await _movieTicket.CinemaCenters.FindAsync(id);
            return cinemaCenter;
        }
    }

}
