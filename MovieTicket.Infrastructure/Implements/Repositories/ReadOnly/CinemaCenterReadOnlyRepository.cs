using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;

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

		public async Task<PageList<CinemaCenterDto>> GetAllCinemaCenter(CinemaCenterSearch search, PagingParameters pagingParameters)
		{
			var cinemaCenters = _movieTicket.CinemaCenters.Select(x=> new CinemaCenterDto
            {
				Id = x.Id,
				Name = x.Name,
				Address = x.Address,
				AddressMap = x.AddressMap,
				AddresCity = x.AddresCity,
				CreateDate = x.CreateDate,
			}).AsQueryable();
			if (!string.IsNullOrEmpty(search.Name))
			{
				cinemaCenters = cinemaCenters.Where(x => x.Name.Contains(search.Name));
			}
			if (!string.IsNullOrEmpty(search.Address))
			{
				cinemaCenters = cinemaCenters.Where(x => x.Address.Contains(search.Address));
			}
            if (!string.IsNullOrEmpty(search.AddresCity))
            {
				cinemaCenters = cinemaCenters.Where(x => x.AddresCity.Contains(search.AddresCity));
			}
			int count = await cinemaCenters.CountAsync();
			var data = await cinemaCenters.Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
					.Take(pagingParameters.PageSize)
					.ToListAsync();
			return new PageList<CinemaCenterDto>(data, count, pagingParameters.PageNumber, pagingParameters.PageSize);
		}

		public async Task<ResponseObject<CinemaCenterDto>> GetById(Guid id)
        {
            var cinemaCenter = await _movieTicket.CinemaCenters.FindAsync(id);
            var cinemaCenterDto = _mapper.Map<CinemaCenterDto>(cinemaCenter);
            if (cinemaCenter == null)
            {
                return new ResponseObject<CinemaCenterDto>
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Không tìm thấy rạp chiếu",
                    Data = null
                };
            }
            return new ResponseObject<CinemaCenterDto>
            {
                Data = cinemaCenterDto,
                Status = StatusCodes.Status200OK,
                Message = "Tìm thấy rạp chiếu"
            };
        }
    }
}