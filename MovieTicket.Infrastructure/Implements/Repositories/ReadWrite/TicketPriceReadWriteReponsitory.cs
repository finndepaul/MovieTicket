using AutoMapper;
using Microsoft.AspNetCore.Http;
using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Entitis;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class TicketPriceReadWriteReponsitory : ITicketPriceReadWriteReponsitory
    {
        private readonly MovieTicketReadWriteDbContext _dbContext;
        private readonly IMapper _map;

        public TicketPriceReadWriteReponsitory(MovieTicketReadWriteDbContext dbContext, IMapper map)
        {
            _dbContext = dbContext;
            _map = map;
        }

        public async Task<ResponseObject<TicketPriceCreateRequest>> Create(TicketPriceCreateRequest request, CancellationToken cancellationToken)
        {
			if (String.IsNullOrEmpty(request.SeatTypeId.ToString()))
			{
				return new ResponseObject<TicketPriceCreateRequest>
				{
					Data = null,
					Message = "Chưa chọn loại ghế.",
					Status = StatusCodes.Status404NotFound
				};
			}
			if (String.IsNullOrEmpty(request.ScreenTypeId.ToString()))
			{
				return new ResponseObject<TicketPriceCreateRequest>
				{
					Data = null,
					Message = "Chưa chọn hình thức chiếu.",
					Status = StatusCodes.Status404NotFound
				};
			}
			if (String.IsNullOrEmpty(request.ScreeningDayId.ToString()))
			{
				return new ResponseObject<TicketPriceCreateRequest>
				{
					Data = null,
					Message = "Chưa chọn ngày chiếu.",
					Status = StatusCodes.Status404NotFound
				};
			}
			if (String.IsNullOrEmpty(request.CinemaTypeId.ToString()))
			{
				return new ResponseObject<TicketPriceCreateRequest>
				{
					Data = null,
					Message = "Chưa chọn loại rạp.",
					Status = StatusCodes.Status404NotFound
				};
			}
			if (String.IsNullOrEmpty(request.Price.ToString()))
			{
				return new ResponseObject<TicketPriceCreateRequest>
				{
					Data = null,
					Message = "Chưa nhập số tiền.",
					Status = StatusCodes.Status404NotFound
				};
			}
			if (!(request.Price >= 30000 && request.Price <= 1000000))
            {
				return new ResponseObject<TicketPriceCreateRequest>
				{
					Data = null,
					Message = "Giá vé chỉ được nhập từ khoảng 30.000 - 1.000.000 VND",
					Status = StatusCodes.Status404NotFound
				};
			}
            var duplicate = _dbContext.TicketPrices.Where(x => x.ScreeningDayId == request.ScreeningDayId && x.ScreenTypeId == request.ScreenTypeId && x.SeatTypeId == request.SeatTypeId && x.CinemaTypeId == request.CinemaTypeId).FirstOrDefault();
            //check trung
            if (duplicate != null)
            {
                return new ResponseObject<TicketPriceCreateRequest>
                {
                    Data = null,
                    Message = "Giá vé này đã tồn tại",
                    Status = StatusCodes.Status400BadRequest
                };
            }
            var ticketPrice = _map.Map<TicketPrice>(request);
            ticketPrice.Status = TicketPriceStatus.Active;
            await _dbContext.TicketPrices.AddAsync(ticketPrice);
            await _dbContext.SaveChangesAsync();
            return new ResponseObject<TicketPriceCreateRequest>
            {
                Data = request,
                Message = "Tạo giá vé thành công",
                Status = StatusCodes.Status200OK
            };
        }

        public async Task<ResponseObject<bool>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var ticketPrice = await _dbContext.TicketPrices.FindAsync(id);
            if (ticketPrice == null)
            {
                return new ResponseObject<bool>
                {
                    Data = false,
                    Message = "Không tìm thấy giá vé",
                    Status = StatusCodes.Status404NotFound
                };
            }
            ticketPrice.Status = TicketPriceStatus.Inactive;
            _dbContext.TicketPrices.Update(ticketPrice);
            await _dbContext.SaveChangesAsync();
            return new ResponseObject<bool>
            {
                Data = true,
                Message = "Xóa giá vé thành công",
                Status = StatusCodes.Status200OK
            };
        }

        public async Task<ResponseObject<TicketPriceUpdateRequest>> Update(TicketPriceUpdateRequest request, CancellationToken cancellationToken)
        {
			//check trung
			if (!request.Validate())
			{
				return new ResponseObject<TicketPriceUpdateRequest>
				{
					Data = null,
					Message = "Giá vé này đã tồn tại",
					Status = StatusCodes.Status404NotFound
				};
			}
			if (!(request.Price >= 30000 && request.Price <= 1000000))
			{
				return new ResponseObject<TicketPriceUpdateRequest>
				{
					Data = null,
					Message = "Giá vé chỉ được nhập từ khoảng 30.000 - 1.000.000 VND",
					Status = StatusCodes.Status404NotFound
				};
			}
			var duplicate = _dbContext.TicketPrices.Where(x => x.ScreeningDayId == request.ScreeningDayId && x.ScreenTypeId == request.ScreenTypeId && x.SeatTypeId == request.SeatTypeId && x.CinemaTypeId == request.CinemaTypeId).FirstOrDefault(x=>x.Id != request.Id);
            //tim
            var ticketPrice = await _dbContext.TicketPrices.FindAsync(request.Id);
			
			if (ticketPrice == null)
            {
                return new ResponseObject<TicketPriceUpdateRequest>
                {
                    Data = null,
                    Message = "Không tìm thấy giá vé",
                    Status = StatusCodes.Status404NotFound
                };
            }
            if (duplicate != null)
            {
                return new ResponseObject<TicketPriceUpdateRequest>
                {
                    Data = null,
                    Message = "Giá vé đã tồn tại",
                    Status = StatusCodes.Status400BadRequest
                };
            }
            ticketPrice.ScreeningDayId = request.ScreeningDayId;
            ticketPrice.ScreenTypeId = request.ScreenTypeId;
            ticketPrice.SeatTypeId = request.SeatTypeId;
            ticketPrice.CinemaTypeId = request.CinemaTypeId;
            ticketPrice.Price = request.Price;
            ticketPrice.Status = request.Status;
            _dbContext.TicketPrices.Update(ticketPrice);
            await _dbContext.SaveChangesAsync();
            return new ResponseObject<TicketPriceUpdateRequest>
            {
                Data = request,
                Message = "Sửa giá vé thành công",
                Status = StatusCodes.Status200OK
            };
        }
    }
}