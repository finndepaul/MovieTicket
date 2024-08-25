using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.Combo;
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
    public class BillReadOnlyRepository : IBillReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext dbContext;
        private readonly IMapper mapper;

        public BillReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IQueryable<BillDto>> GetAllAsync()
        {
            var bills = dbContext.Bills
                .Select(bill => new BillDto
                {
                    Id = bill.Id,
                    TotalMoney = bill.TotalMoney,
                    CreateTime = bill.CreateTime,
                    BarCode = bill.BarCode,
                    Status = bill.Status
                });

            if (!bills.Any())
            {
                throw new InvalidOperationException("No bills found.");
            }

            return bills;
        }

        public async Task<BillDtoGetById?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid ID.", nameof(id));
            }

            var bill = await dbContext.Bills
                .Where(b => b.Id == id)
                .Select(bill => new BillDtoGetById
                {
                    Id = bill.Id,
                    TotalMoney = bill.TotalMoney,
                    CreateTime = bill.CreateTime,
                    BarCode = bill.BarCode,
                    Status = bill.Status,
                    Combos = bill.BillCombos.Select(bc => mapper.Map<ComboDto>(bc.Combo)!).ToList()
                })
                .FirstOrDefaultAsync();

            if (bill == null)
            {
                throw new InvalidOperationException($"No bill found with ID {id}.");
            }

            return bill;
        }
    }

}
