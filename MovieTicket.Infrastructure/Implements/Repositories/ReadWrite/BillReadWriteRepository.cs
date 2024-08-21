using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.Combo;
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
    public class BillReadWriteRepository : IBillReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext dbContext;
        private readonly IMapper mapper;

        public BillReadWriteRepository(MovieTicketReadWriteDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<ResponseObject<BillDto>> CreateAsync(CreateBillRequest createBillRequest)
        {
            try
            {
                var billEntity = mapper.Map<Bill>(createBillRequest);
                await dbContext.Bills.AddAsync(billEntity);
                await dbContext.SaveChangesAsync();

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

        public async Task<ResponseObject<BillDto>?> UpdateAsync(Guid id, UpdateBillRequest updateBillRequest)
        {
            try
            {
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

                mapper.Map(updateBillRequest, billEntity);
                dbContext.Bills.Update(billEntity);
                await dbContext.SaveChangesAsync();

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

        public async Task<ResponseObject<BillDto>?> DeleteAsync(Guid id)
        {
            try
            {
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

                dbContext.Bills.Remove(billEntity);
                await dbContext.SaveChangesAsync();

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
    }

}
