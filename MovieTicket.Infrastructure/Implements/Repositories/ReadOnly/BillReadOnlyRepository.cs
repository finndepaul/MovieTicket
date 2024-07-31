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

        public IQueryable<BillDto> GetAllAsync()
        {
            return dbContext.Bills.AsNoTracking().Select(bill => mapper.Map<BillDto>(bill)!);
        }

        public IQueryable<BillWithComboRequest> GetAllWithCombosAsync()
        {
            var bills = dbContext.Bills
                .Select(bill => new BillWithComboRequest
                {
                    Id = bill.Id,
                    TotalMoney = bill.TotalMoney,
                    CreateTime = bill.CreateTime,
                    BarCode = bill.BarCode,
                    Status = bill.Status,
                    Combos = bill.BillCombos.Select(bc => mapper.Map<ComboDto>(bc.Combo)!).ToList()
                });

            return bills;
        }

        public async Task<BillDto?> GetByIdAsync(Guid Id)
        {
            var billModel = await dbContext.Bills.FirstOrDefaultAsync(x => x.Id == Id);
            if (billModel == null)
            {
                return null;
            }
            var billDto = mapper.Map<BillDto>(billModel);
            return billDto;
        }
    }

}
