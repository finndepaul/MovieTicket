using AutoMapper;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
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

        public async Task<BillDto> CreateAsync(CreateBillRequest createBillRequest)
        {
            if (createBillRequest == null)
            {
                throw new ArgumentNullException(nameof(createBillRequest), "CreateBillRequest cannot be null.");
            }

            var bill = mapper.Map<Bill>(createBillRequest);
            if (bill == null)
            {
                throw new InvalidOperationException("Mapping resulted in a null Bill entity.");
            }

            await dbContext.Bills.AddAsync(bill);
            await dbContext.SaveChangesAsync();

            // Thêm các BillCombo mới
            var billCombos = createBillRequest.ComboIds.Select(comboId => new BillCombo
            {
                Bill = bill,
                ComboId = comboId
            }).ToList();
            await dbContext.BillCombos.AddRangeAsync(billCombos); 
            await dbContext.SaveChangesAsync();

            return mapper.Map<BillDto>(bill) ?? throw new InvalidOperationException("Mapping resulted in a null BillDto.");
        }

        public async Task<BillDto?> UpdateAsync(Guid id, UpdateBillRequest updateBillRequest)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid ID.", nameof(id));
            }

            if (updateBillRequest == null)
            {
                throw new ArgumentNullException(nameof(updateBillRequest), "UpdateBillRequest cannot be null.");
            }

            var result = await dbContext.Bills.FindAsync(id);
            if (result == null)
            {
                return null;
            }

            // Xóa các BillCombo hiện tại
            var existingBillCombos = dbContext.BillCombos.Where(bc => bc.BillId == id);
            dbContext.BillCombos.RemoveRange(existingBillCombos);

            // Thêm các BillCombo mới
            var billCombos = updateBillRequest.ComboIds.Select(comboId => new BillCombo
            {
                Bill = result,
                ComboId = comboId
            }).ToList();
            await dbContext.BillCombos.AddRangeAsync(billCombos);

            // Cập nhật các thuộc tính khác của Bill
            mapper.Map(updateBillRequest, result);
            await dbContext.SaveChangesAsync();

            return mapper.Map<BillDto>(result);
        }

        public async Task<BillDto?> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid ID.", nameof(id));
            }

            var result = await dbContext.Bills.FindAsync(id);
            if (result == null)
            {
                return null;
            }

            dbContext.Bills.Remove(result);
            await dbContext.SaveChangesAsync();
            return mapper.Map<BillDto>(result);
        }
    }

}
