﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.DataTransferObjs.TicketPrice;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using System.Threading;

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
					MembershipId = b.MembershipId,
					FilmName = (from ticket in _dbContext.Tickets
								join showtime in _dbContext.ShowTimes on ticket.ShowTimeId equals showtime.Id
								join schedule in _dbContext.Schedules on showtime.ScheduleId equals schedule.Id
								join film in _dbContext.Films on schedule.FilmId equals film.Id
								where ticket.BillId == b.Id
								select film.Name).FirstOrDefault(),
					TotalMoney = b.TotalMoney,
					CreateTime = b.CreateTime,
					BarCode = b.BarCode,
					Status = b.Status.ToString()
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
						MembershipId = b.MembershipId,
						BillCode = int.Parse(DateTime.Now.ToString("HHmmss")),
						TotalMoney = b.TotalMoney,
						AfterDiscount = b.AfterDiscount,
						FilmName = (from ticket in _dbContext.Tickets
									join showtime in _dbContext.ShowTimes on ticket.ShowTimeId equals showtime.Id
									join schedule in _dbContext.Schedules on showtime.ScheduleId equals schedule.Id
									join film in _dbContext.Films on schedule.FilmId equals film.Id
									where ticket.BillId == b.Id
									select film.Name).FirstOrDefault(),
						CreateTime = b.CreateTime,
						BarCode = b.BarCode,
						Status = b.Status.ToString(),
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

		public async Task<PageList<BillsDto>> GetListBillWithPaginationAsync(BillWithPaginationRequest request, PagingParameters pagingParameters,CancellationToken cancellationToken)
		{
			var query = _dbContext.Bills
				.Join(_dbContext.Tickets, b => b.Id, t => t.BillId, (b,t) => new {b, t})
				.Join(_dbContext.ShowTimes, group => group.t.ShowTimeId, s => s.Id, (group, s) => new { group, s })
				.Join(_dbContext.ScreenTypes, group => group.s.ScreenTypeId,sct => sct.Id, (group, sct)=> new { group, sct})
				.Join(_dbContext.Cinemas, group => group.group.s.CinemaId, c=>c.Id,(group, c)=> new { group, c})
				.Join(_dbContext.CinemaCenters, group => group.c.CinemaCenterId,cc => cc.Id,(group, cc)=> new { group, cc })
				.Join(_dbContext.Schedules, group=>group.group.group.group.s.ScheduleId,sc =>sc.Id,(group,sc)=> new {group,sc})
				.Join(_dbContext.Films,group=>group.sc.FilmId,f=>f.Id,(group,f)=>new { group,f});
			if (!String.IsNullOrEmpty(request.FilmName))
			{
				query = query.Where(x => x.f.Name.Equals(request.FilmName));
			}
			if (!String.IsNullOrEmpty(request.BarCode))
			{
				query = query.Where(x => x.group.group.group.group.group.group.b.BarCode.Equals(request.BarCode));
			}
			if (request.Status.HasValue)
			{
				query = query.Where(x => x.group.group.group.group.group.group.b.Status == request.Status);
			}
			if (request.Type.HasValue)
			{
				query = query.Where(x => x.group.sc.Type == request.Type);
			}
			if (!String.IsNullOrEmpty(request.CinemaType_Name))
			{
				query = query.Where(x => x.group.group.group.group.sct.Type + " " + x.group.group.cc.Name == request.CinemaType_Name);
			}
			if (request.StartTime != null && request.EndTime != null)
			{
				query = query.Where(x => x.group.group.group.group.group.group.b.CreateTime >= request.StartTime && x.group.group.group.group.group.group.b.CreateTime <= request.EndTime);
			}
			var result = await query
				.Select(x => new BillsDto
				{
					Id = x.group.group.group.group.group.group.b.Id,
					Type = x.group.sc.Type,
					CinemaType_Name = x.group.group.group.group.sct.Type + " " + x.group.group.cc.Name,
					FilmName = x.f.Name,
					TotalMoney = x.group.group.group.group.group.group.b.AfterDiscount,
					CreateTime = x.group.group.group.group.group.group.b.CreateTime,
					BarCode = x.group.group.group.group.group.group.b.BarCode,
					Status = x.group.group.group.group.group.group.b.Status
				}).OrderBy(x=>x.CreateTime).Distinct().AsNoTracking().ToListAsync();
			var count = result.Count;
			var data = await query
				.Select(x => new BillsDto
				{
					Id = x.group.group.group.group.group.group.b.Id,
					Type = x.group.sc.Type,
                    CinemaType_Name = x.group.group.group.group.sct.Type + " " + x.group.group.cc.Name,
                    FilmName = x.f.Name,
					TotalMoney = x.group.group.group.group.group.group.b.AfterDiscount,
					CreateTime = x.group.group.group.group.group.group.b.CreateTime,
					BarCode = x.group.group.group.group.group.group.b.BarCode,
					Status = x.group.group.group.group.group.group.b.Status
				}).OrderBy(x => x.CreateTime).Distinct().Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
			.Take(pagingParameters.PageSize)
				.AsNoTracking().ToListAsync(cancellationToken);
			return new PageList<BillsDto>(data, count, pagingParameters.PageNumber, pagingParameters.PageSize);
		}
	}
}