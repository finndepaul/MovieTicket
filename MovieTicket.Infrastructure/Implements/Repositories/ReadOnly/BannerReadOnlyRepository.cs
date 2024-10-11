using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using MovieTicket.Application.DataTransferObjs.Banner;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class BannerReadOnlyRepository : IBannerReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext dbContext;
        private readonly IMapper mapper;

        public BannerReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IQueryable<BannerDTO>> GetAllAsync()
        {
            var bannerModel = dbContext.Banners.AsQueryable();
            if (bannerModel == null)
            {
                return null;
            }
            var bannerDtos = bannerModel.ProjectTo<BannerDTO>(mapper.ConfigurationProvider);
            return bannerDtos;
        }

        public async Task<ResponseObject<BannerDTO>> GetByIdAsync(Guid id)
        {
            var bannerModel = await dbContext.Banners.FindAsync(id);
            if (bannerModel == null)
            {
                return new ResponseObject<BannerDTO>
                {
                    Status = StatusCodes.Status404NotFound,
                    Message = "Banner not found.",
                    Data = null
                };
            }
            return new ResponseObject<BannerDTO>
            {
                Status = StatusCodes.Status200OK,
                Message = "Get banner success.",
                Data = mapper.Map<BannerDTO>(bannerModel)
            };
        }
    }
}