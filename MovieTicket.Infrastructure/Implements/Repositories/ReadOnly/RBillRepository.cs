using Microsoft.EntityFrameworkCore;
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
    public class RBillRepository : IRBillRepository
    {
        private readonly MovieTicketReadOnlyDbContext dbContext;

        public RBillRepository(MovieTicketReadOnlyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Bill> GetAllAsync()
        {
            var query = from bill in dbContext.Bills
                        join billCombo in dbContext.BillCombos on bill.Id equals billCombo.BillId into billCombos
                        select new Bill
                        {
                            Id = bill.Id,
                            TotalMoney = bill.TotalMoney,
                            CreateTime = bill.CreateTime,
                            BarCode = bill.BarCode,
                            Status = bill.Status,
                            BillCombos = billCombos.Select(bc => new BillCombo
                            {
                                BillId = bc.BillId,
                                ComboId = bc.ComboId,
                                Bill = new Bill
                                {
                                    Id = bc.Bill.Id,
                                    TotalMoney = bc.Bill.TotalMoney,
                                    BarCode = bc.Bill.BarCode,
                                    Status = bc.Bill.Status
                                },
                                Combo = new Combo
                                {
                                    Id = bc.Combo.Id,
                                    Name = bc.Combo.Name,
                                    Price = bc.Combo.Price
                                }
                            }).ToList()
                        };

            return query.AsQueryable();


        }

        public IQueryable<Combo?> GetBillByCombo(Guid id)
        {
            var result = dbContext.BillCombos
                .Where(x => x.BillId == id)
                .Select(x => x.Combo).AsQueryable();
            return result;
        }

        public async Task<Bill?> GetByIdAsync(Guid Id)
        {
            var result = await dbContext.Bills.FirstOrDefaultAsync(x => x.Id == Id);
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }

}
