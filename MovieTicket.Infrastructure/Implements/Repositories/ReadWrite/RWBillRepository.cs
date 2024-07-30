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
    public class RWBillRepository : IRWBillRepository
    {
        private readonly MovieTicketReadWriteDbContext dbContext;

        public RWBillRepository(MovieTicketReadWriteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Bill> CreateAsync(Bill bill, List<Guid> comboId)
        {
            var billCombos = comboId.Select(comboId => new BillCombo
            {
                Bill = bill,
                ComboId = comboId
            }).ToList();
            await dbContext.BillCombos.AddRangeAsync(billCombos);
            await dbContext.Bills.AddAsync(bill);
            await dbContext.SaveChangesAsync();
            return bill;
        }

        public async Task<Bill?> DeleteAsync(Guid id)
        {
            var result = await dbContext.Bills.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            dbContext.Bills.Remove(result);
            await dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<Bill?> UpdateAsync(Guid id, Bill bill, List<Guid> comboIds)
        {
            var result = await dbContext.Bills.FindAsync(id);
            if (result == null)
            {
                return null;
            }

            // Xóa các BillCombo hiện tại
            var existingBillCombos = dbContext.BillCombos.Where(bc => bc.BillId == id);
            dbContext.BillCombos.RemoveRange(existingBillCombos);

            // Thêm các BillCombo mới
            var billCombos = comboIds.Select(comboId => new BillCombo
            {
                Bill = result,
                ComboId = comboId
            }).ToList();
            await dbContext.BillCombos.AddRangeAsync(billCombos);

            // Cập nhật các thuộc tính khác của Bill
            result.TotalMoney = bill.TotalMoney;
            result.CreateTime = bill.CreateTime;
            result.BarCode = bill.BarCode;
            result.Status = bill.Status;

            await dbContext.SaveChangesAsync();
            return result;
        }
    }

}
