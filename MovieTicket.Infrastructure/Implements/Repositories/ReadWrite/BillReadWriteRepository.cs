using AutoMapper;
using Microsoft.AspNetCore.Http;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class BillReadWriteRepository : IBillReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext dbContext;
        private readonly IMapper mapper;

        public BillReadWriteRepository(MovieTicketReadWriteDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        // Phương thức tạo mới một hóa đơn
        public async Task<ResponseObject<BillDto>> CreateAsync(CreateBillRequest createBillRequest)
        {
            try
            {
                // Ánh xạ CreateBillRequest sang Bill entity
                var billEntity = mapper.Map<Bill>(createBillRequest);
                // Thiết lập thời gian tạo và trạng thái ban đầu cho hóa đơn
                billEntity.CreateTime = DateTime.Now.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
                billEntity.Status = BillStatus.Pending;
                // Tạo mã vạch cho hóa đơn
                billEntity.BarCode = GenerateBarcode(billEntity.Id.ToString());
                // Thêm hóa đơn vào cơ sở dữ liệu
                await dbContext.Bills.AddAsync(billEntity);
                await dbContext.SaveChangesAsync();

                // Ánh xạ Bill entity sang BillDto
                var billDto = mapper.Map<BillDto>(billEntity);
                return new ResponseObject<BillDto>
                {
                    Data = billDto,
                    Status = StatusCodes.Status201Created,
                    Message = "Bill created successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<BillDto>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = $"An error occurred while creating the bill: {ex.Message}"
                };
            }
        }

        // Phương thức cập nhật một hóa đơn
        public async Task<ResponseObject<BillDto>?> UpdateAsync(Guid id, UpdateBillRequest updateBillRequest)
        {
            try
            {
                // Tìm hóa đơn theo id
                var billEntity = await dbContext.Bills.FindAsync(id);
                if (billEntity == null)
                {
                    return new ResponseObject<BillDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status404NotFound,
                        Message = "Bill not found"
                    };
                }

                // Ánh xạ UpdateBillRequest sang Bill entity
                mapper.Map(updateBillRequest, billEntity);
                // Thiết lập lại thời gian tạo và trạng thái cho hóa đơn
                billEntity.CreateTime = DateTime.Now.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute);
                billEntity.Status = BillStatus.Pending;
                // Cập nhật hóa đơn trong cơ sở dữ liệu
                dbContext.Bills.Update(billEntity);
                await dbContext.SaveChangesAsync();

                // Ánh xạ Bill entity sang BillDto
                var billDto = mapper.Map<BillDto>(billEntity);
                return new ResponseObject<BillDto>
                {
                    Data = billDto,
                    Status = StatusCodes.Status200OK,
                    Message = "Bill updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<BillDto>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = $"An error occurred while updating the bill: {ex.Message}"
                };
            }
        }

        // Phương thức xóa một hóa đơn
        public async Task<ResponseObject<BillDto>?> DeleteAsync(Guid id)
        {
            try
            {
                // Tìm hóa đơn theo id
                var billEntity = await dbContext.Bills.FindAsync(id);
                if (billEntity == null)
                {
                    return new ResponseObject<BillDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status404NotFound,
                        Message = "Bill not found"
                    };
                }

                // Xóa hóa đơn khỏi cơ sở dữ liệu
                dbContext.Bills.Remove(billEntity);
                await dbContext.SaveChangesAsync();

                // Ánh xạ Bill entity sang BillDto
                var billDto = mapper.Map<BillDto>(billEntity);
                return new ResponseObject<BillDto>
                {
                    Data = billDto,
                    Status = StatusCodes.Status200OK,
                    Message = "Bill deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<BillDto>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = $"An error occurred while deleting the bill: {ex.Message}"
                };
            }
        }

        // Phương thức tạo mã vạch cho hóa đơn
        private string GenerateBarcode(string data)
        {
            var barcodeWriter = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 150,
                    Width = 300
                }
            };

            var pixelData = barcodeWriter.Write(data.Substring(0, 12));
            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height))
            {
                using (var ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    var imageBytes = ms.ToArray();
                    return Convert.ToBase64String(imageBytes);
                }
            }
        }

		public async Task<ResponseObject<bool>?> UpdateStatusAsync(Guid id, BillStatus status)
		{
			var billEntity = dbContext.Bills.Find(id);
			if (billEntity == null)
			{
				return new ResponseObject<bool>
				{
					Data = false,
					Status = StatusCodes.Status404NotFound,
					Message = "Không tìm thấy hóa đơn"
				};
			}
            billEntity.Status = status;
			dbContext.Bills.Update(billEntity);
			await dbContext.SaveChangesAsync();
			return new ResponseObject<bool>
			{
				Data = true,
				Status = StatusCodes.Status200OK,
				Message = "Sửa trạng thái hóa đơn thành công"
			};
		}
	}
}