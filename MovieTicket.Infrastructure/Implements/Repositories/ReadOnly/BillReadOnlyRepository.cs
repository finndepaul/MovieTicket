using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Database.AppDbContexts;

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

        // Phương thức bất đồng bộ để lấy tất cả các Bill dưới dạng IQueryable<BillDto>
        public async Task<IQueryable<BillDto>> GetAllAsync()
        {
            // Lấy danh sách các Bill từ dbContext và chuyển đổi sang BillDto
            var bills = dbContext.Bills
                .Select(bill => new BillDto
                {
                    Id = bill.Id,
                    TotalMoney = bill.TotalMoney,
                    CreateTime = bill.CreateTime,
                    BarCode = bill.BarCode,
                    Status = bill.Status
                });

            // Nếu không có Bill nào, ném ra ngoại lệ
            if (!bills.Any())
            {
                throw new InvalidOperationException("No bills found.");
            }

            return bills;
        }

        // Phương thức bất đồng bộ để lấy Bill theo ID
        public async Task<BillDtoGetById?> GetByIdAsync(Guid id)
        {
            // Kiểm tra nếu ID là rỗng, ném ra ngoại lệ
            if (id == Guid.Empty)
            {
                throw new ArgumentException("Invalid ID.", nameof(id));
            }

            // Lấy Bill từ dbContext theo ID và chuyển đổi sang BillDtoGetById
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

            // Nếu không tìm thấy Bill, ném ra ngoại lệ
            if (bill == null)
            {
                throw new InvalidOperationException($"No bill found with ID {id}.");
            }

            return bill;
        }
    }
}