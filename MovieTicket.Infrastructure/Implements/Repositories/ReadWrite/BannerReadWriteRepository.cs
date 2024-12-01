using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Banner;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class BannerReadWriteRepository : IBannerReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _movieTicket;

        public BannerReadWriteRepository(MovieTicketReadWriteDbContext movieTicket)
        {
            _movieTicket = movieTicket;
        }

        public async Task<ResponseObject<BannerDTO>> Create(BannerCreateRequest request)
        {
            try
            {
                if (_movieTicket.Banners.Any(x => x.Name == request.Name))
                {
                    return new ResponseObject<BannerDTO>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Banner đã tồn tại",
                        Data = null
                    };
                }
                var banner = new Banner
                {
                    Name = request.Name,
                    Image = request.Image,
                    Status = BannerStatus.Inactive,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = null
                };
                await _movieTicket.Banners.AddAsync(banner);
                await _movieTicket.SaveChangesAsync();
                return new ResponseObject<BannerDTO>
                {
                    Data = new BannerDTO
                    {
                        Id = banner.Id,
                        Name = banner.Name,
                        Image = banner.Image,
                        Status = banner.Status,
                        CreatedDate = banner.CreatedDate
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Thêm banner thành công"
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<BannerDTO>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = e.Message
                };
            }
        }

        public async Task<ResponseObject<Banner>> HardDelete(Guid id)
        {
            try
            {
                var model = await _movieTicket.Banners.FindAsync(id);
                if (model == null)
                {
                    return new ResponseObject<Banner>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Banner không tồn tại",
                        Data = null
                    };
                }
                _movieTicket.Banners.Remove(model);
                await _movieTicket.SaveChangesAsync();
                return new ResponseObject<Banner>
                {
                    Data = null,
                    Status = StatusCodes.Status200OK,
                    Message = "Xóa thành công"
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<Banner>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = e.Message
                };
            }
        }

        public async Task<ResponseObject<BannerDTO>> Update(BannerUpdateRequest request)
        {
            try
            {
                var bannerModel = await _movieTicket.Banners.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (bannerModel == null)
                {
                    return new ResponseObject<BannerDTO>
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Banner không tồn tại",
                        Data = null
                    };
                }
                bannerModel.Name = request.Name;
                bannerModel.Image = request.Image;
                bannerModel.Status = request.Status;
                bannerModel.UpdatedDate = DateTime.Now;
                _movieTicket.Update(bannerModel);
                await _movieTicket.SaveChangesAsync();
                return new ResponseObject<BannerDTO>
                {
                    Data = new BannerDTO
                    {
                        Id = bannerModel.Id,
                        Name = bannerModel.Name,
                        Image = bannerModel.Image,
                        Status = bannerModel.Status,
                        CreatedDate = bannerModel.CreatedDate,
                        UpdatedDate = (DateTime)bannerModel.UpdatedDate
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Update Banner thành công"
                };
            }
            catch (Exception e)
            {
                return new ResponseObject<BannerDTO>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = e.Message
                };
            }
        }
    }
}