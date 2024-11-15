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
		private readonly MovieTicketReadOnlyDbContext _dbContext;
		private readonly IMapper mapper;

		public BillReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext, IMapper mapper)
		{
			this._dbContext = dbContext;
			this.mapper = mapper;
		}

		// Phương thức bất đồng bộ để lấy tất cả các Bill dưới dạng IQueryable<BillDto>
		public async Task<IQueryable<BillDto>> GetAllAsync()
		{
			// Lấy danh sách các Bill từ dbContext và chuyển đổi sang BillDto
			var bills = _dbContext.Bills
				.Select(b => new BillDto
				{
					Id = b.Id,
					FilmName = (from ticket in _dbContext.Tickets
								join showtime in _dbContext.ShowTimes on ticket.ShowTimeId equals showtime.Id
								join schedule in _dbContext.Schedules on showtime.ScheduleId equals schedule.Id
								join film in _dbContext.Films on schedule.FilmId equals film.Id
								where ticket.BillId == b.Id
								select film.Name).FirstOrDefault(),
					TotalMoney = b.TotalMoney,
					CreateTime = b.CreateTime,
					BarCode = b.BarCode,
					Status = b.Status
				});

			// Nếu không có Bill nào, ném ra ngoại lệ
			if (!bills.Any())
			{
				throw new InvalidOperationException("No bills found.");
			}

			return bills;
		}

		// Phương thức bất đồng bộ để lấy Bill theo ID
		public async Task<BillDetailDto?> GetByIdAsync(Guid id)
		{
			// Kiểm tra nếu ID là rỗng, ném ra ngoại lệ
			if (id == Guid.Empty)
			{
				throw new ArgumentException("Invalid ID.", nameof(id));
			}

			// Lấy Bill từ dbContext theo ID và chuyển đổi sang BillDtoGetById
			var bill = await _dbContext.Bills
					.Where(x => x.Id == id)
					.Select(b => new BillDetailDto
					{
						Id = b.Id,
						BillCode = int.Parse(DateTime.Now.ToString("HHmmss")),
						TotalMoney = b.TotalMoney,
						FilmName = (from ticket in _dbContext.Tickets
									join showtime in _dbContext.ShowTimes on ticket.ShowTimeId equals showtime.Id
									join schedule in _dbContext.Schedules on showtime.ScheduleId equals schedule.Id
									join film in _dbContext.Films on schedule.FilmId equals film.Id
									where ticket.BillId == b.Id
									select film.Name).FirstOrDefault(),
						CreateTime = b.CreateTime,
						BarCode = b.BarCode,
						Status = b.Status,
						Combos = b.BillCombos.Select(bc => mapper.Map<ComboDto>(bc.Combo)!).ToList()
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