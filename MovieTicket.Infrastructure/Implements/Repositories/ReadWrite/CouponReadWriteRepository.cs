using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Coupon;
using MovieTicket.Application.DataTransferObjs.Coupon.Requests;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
	public class CouponReadWriteRepository : ICouponReadWriteRepository
	{
		private readonly MovieTicketReadWriteDbContext _db;

		public CouponReadWriteRepository(MovieTicketReadWriteDbContext db)
		{
			_db = db;
		}

		public async Task<ResponseObject<CouponDto>> CreateAsync(CreateCouponRequest request, CancellationToken cancellationToken)
		{
			try
			{
				if (string.IsNullOrEmpty(request.CouponCode) ||
					string.IsNullOrEmpty(request.AmountValue.ToString()))
				{
					return new ResponseObject<CouponDto>
					{
						Data = null,
						Status = StatusCodes.Status400BadRequest,
						Message = "Không được để trống trường dữ liệu."
					};
				}
				if (await _db.Coupons.AnyAsync(x => x.CouponCode == request.CouponCode.Trim()))
				{
					return new ResponseObject<CouponDto>
					{
						Data = null,
						Status = StatusCodes.Status400BadRequest,
						Message = "Mã giảm giá đã tồn tại."
					};
				}
				if (request.EndDate.Date < DateTime.Now.Date && request.StartDate.Date < DateTime.Now.Date)
				{
					return new ResponseObject<CouponDto>
					{
						Data = null,
						Status = StatusCodes.Status400BadRequest,
						Message = "Thời gian áp dụng phải bắt đầu từ ngày hôm nay."
					};
				}
				if (request.StartDate.Date > request.EndDate.Date)
				{
					return new ResponseObject<CouponDto>
					{
						Data = null,
						Status = StatusCodes.Status400BadRequest,
						Message = "Thời gian kết thúc không được nhỏ hơn thời gian bắt đầu."
					};
				}
				if (request.AmountValue < 0)
				{
					return new ResponseObject<CouponDto>
					{
						Data = null,
						Status = StatusCodes.Status400BadRequest,
						Message = "Giá trị phải lớn hơn 0."
					};
				}
				var coupon = new Coupon
				{
					Id = Guid.NewGuid(),
					CouponCode = request.CouponCode.Trim(),
					AmountValue = request.AmountValue,
					StartDate = request.StartDate,
					EndDate = request.EndDate,
					IsActive = request.IsActive,
				};
				await _db.Coupons.AddAsync(coupon, cancellationToken);
				await _db.SaveChangesAsync(cancellationToken);
				return new ResponseObject<CouponDto>
				{
					Data = new CouponDto
					{
						Id = coupon.Id,
						CouponCode = coupon.CouponCode,
						AmountValue = coupon.AmountValue,
						StartDate = coupon.StartDate,
						EndDate = coupon.EndDate,
						IsActive = coupon.IsActive ? "Đang hoạt động" : "Ngưng hoạt động"
					},
					Status = StatusCodes.Status201Created,
					Message = "Tạo mới thành công."
				};
			}
			catch (Exception ex)
			{
				return new ResponseObject<CouponDto>
				{
					Data = null,
					Status = StatusCodes.Status500InternalServerError,
					Message = "Error: " + ex.Message
				};
			}
		}

		public async Task<ResponseObject<CouponDto>> DeleteAsync(Guid couponId, CancellationToken cancellationToken)
		{
			try
			{
				var coupon = await _db.Coupons.FindAsync(couponId);
				if (coupon == null)
				{
					return new ResponseObject<CouponDto>
					{
						Data = null,
						Status = StatusCodes.Status404NotFound,
						Message = "Không tìm thấy mã giảm giá."
					};
				}
				_db.Coupons.Remove(coupon);
				await _db.SaveChangesAsync(cancellationToken);
				return new ResponseObject<CouponDto>
				{
					Data = new CouponDto
					{
						Id = coupon.Id,
						AmountValue = coupon.AmountValue,
						IsActive = coupon.IsActive ? "Đang hoạt động" : "Ngưng hoạt động",
						CouponCode = coupon.CouponCode,
						EndDate = coupon.EndDate,
						StartDate = coupon.StartDate
					},
					Status = StatusCodes.Status200OK,
					Message = "Xóa thành công."
				};
			}
			catch (Exception ex)
			{
				return new ResponseObject<CouponDto>
				{
					Data = null,
					Status = StatusCodes.Status500InternalServerError,
					Message = "Error: " + ex.Message
				};
			}
		}

		public async Task<ResponseObject<CouponDto>> UpdateAsync(UpdateCouponRequest request, CancellationToken cancellationToken)
		{
			try
			{
				if (string.IsNullOrEmpty(request.CouponCode) ||
					string.IsNullOrEmpty(request.AmountValue.ToString()))
				{
					return new ResponseObject<CouponDto>
					{
						Data = null,
						Status = StatusCodes.Status400BadRequest,
						Message = "Không được để trống trường dữ liệu."
					};
				}
				if (request.StartDate.Date > request.EndDate.Date)
				{
					return new ResponseObject<CouponDto>
					{
						Data = null,
						Status = StatusCodes.Status400BadRequest,
						Message = "Thời gian kết thúc không được nhỏ hơn thời gian bắt đầu."
					};
				}
				if (request.AmountValue < 0)
				{
					return new ResponseObject<CouponDto>
					{
						Data = null,
						Status = StatusCodes.Status400BadRequest,
						Message = "Giá trị phải lớn hơn 0."
					};
				}
				var model = await _db.Coupons.FindAsync(request.Id);
				if (model == null)
				{
					return new ResponseObject<CouponDto>
					{
						Data = null,
						Status = StatusCodes.Status404NotFound,
						Message = "Không tìm thấy mã giảm giá."
					};
				}
				model.StartDate = request.StartDate;
				model.EndDate = request.EndDate;
				model.AmountValue = request.AmountValue;
				model.IsActive = request.IsActive;
				model.CouponCode = request.CouponCode;
				_db.Coupons.Update(model);
				await _db.SaveChangesAsync(cancellationToken);
				return new ResponseObject<CouponDto>
				{
					Data = new CouponDto
					{
						Id = model.Id,
						CouponCode = model.CouponCode,
						AmountValue = model.AmountValue,
						StartDate = model.StartDate,
						EndDate = model.EndDate,
						IsActive = model.IsActive ? "Đang hoạt động" : "Ngưng hoạt động"
					},
					Status = StatusCodes.Status200OK,
					Message = "Cập nhật thành công."
				};
			}
			catch (Exception ex)
			{
				return new ResponseObject<CouponDto>
				{
					Data = null,
					Status = StatusCodes.Status500InternalServerError,
					Message = "Error: " + ex.Message
				};
			}
		}
	}
}