using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Bill;
using MovieTicket.Application.DataTransferObjs.Combo;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class BillReadOnlyRepository : IBillReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _dbContext;
        private readonly IMapper _mapper;

        public BillReadOnlyRepository(MovieTicketReadOnlyDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<PageList<BillsDto>> GetUserBookingHistoryAsync(Guid userId, PagingParameters pagingParameters, CancellationToken cancellationToken)
        {
            var query = _dbContext.Bills
                .Where(b => b.AccountId == userId && b.Status == BillStatus.Paid)
                .Join(_dbContext.Tickets, b => b.Id, t => t.BillId, (b, t) => new { b, t })
                .Join(_dbContext.ShowTimes, bt => bt.t.ShowTimeId, s => s.Id, (bt, s) => new { bt.b, bt.t, s })
                .Join(_dbContext.Schedules, bts => bts.s.ScheduleId, sc => sc.Id, (bts, sc) => new { bts.b, bts.t, bts.s, sc })
                .Join(_dbContext.Films, btsc => btsc.sc.FilmId, f => f.Id, (btsc, f) => new { btsc.b, btsc.t, btsc.s, btsc.sc, f })
                .Join(_dbContext.ScreenTypes, btscf => btscf.s.ScreenTypeId, st => st.Id, (btscf, st) => new { btscf.b, btscf.t, btscf.s, btscf.sc, btscf.f, st })
                .Join(_dbContext.Cinemas, btscfs => btscfs.s.CinemaId, c => c.Id, (btscfs, c) => new { btscfs.b, btscfs.t, btscfs.s, btscfs.sc, btscfs.f, btscfs.st, c })
                .Join(_dbContext.CinemaCenters, btscfsc => btscfsc.c.CinemaCenterId, cc => cc.Id, (btscfsc, cc) => new { btscfsc.b, btscfsc.t, btscfsc.s, btscfsc.sc, btscfsc.f, btscfsc.st, btscfsc.c, cc })
                .Select(btscfsc => new BillsDto
                {
                    Id = btscfsc.b.Id,
                    CinemaName = btscfsc.cc.Name,
                    FilmName = btscfsc.f.Name,
                    FilmPoster = btscfsc.f.Poster,
                    FilmRating = btscfsc.f.Rating,
                    ShowStartTime = btscfsc.s.StartTime,
                    ShowEndTime = btscfsc.s.EndTime,
                    TotalMoney = btscfsc.b.AfterDiscount,
                    CreateTime = btscfsc.b.CreateTime,
                    BarCode = btscfsc.b.BarCode,
                    Status = btscfsc.b.Status
                }).Distinct();

            var count = await query.CountAsync(cancellationToken);
            var data = await query
                .OrderBy(b => b.CreateTime)
                .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new PageList<BillsDto>(data, count, pagingParameters.PageNumber, pagingParameters.PageSize);
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
                    .Join(_dbContext.Memberships, b => b.MembershipId, m => m.Id, (b, m) => new { b, m })
                    .Where(x => x.b.Id == id)
                    .Select(b => new BillDetailDto
                    {
                        Id = b.b.Id,
                        UserAcountId = b.m.AccountId,
                        MembershipId = b.b.MembershipId,
                        AccountId = b.b.AccountId,
                        BillCode = int.Parse(DateTime.Now.ToString("HHmmss")),
                        TotalMoney = b.b.TotalMoney,
                        AfterDiscount = b.b.AfterDiscount,
                        FilmName = (from ticket in _dbContext.Tickets
                                    join showtime in _dbContext.ShowTimes on ticket.ShowTimeId equals showtime.Id
                                    join schedule in _dbContext.Schedules on showtime.ScheduleId equals schedule.Id
                                    join film in _dbContext.Films on schedule.FilmId equals film.Id
                                    where ticket.BillId == b.b.Id
                                    select film.Name).FirstOrDefault(),
                        CreateTime = b.b.CreateTime,
                        BarCode = b.b.BarCode,
                        Status = b.b.Status.ToString(),
                        Combos = b.b.BillCombos.Select(bc => _mapper.Map<ComboDto>(bc.Combo)!).ToList()
                    })
                    .FirstOrDefaultAsync();
            // Nếu không tìm thấy Bill, ném ra ngoại lệ
            if (bill == null)
            {
                throw new InvalidOperationException($"No bill found with ID {id}.");
            }

            return bill;
        }
        public async Task<PageList<BillsDto>> GetListBillWithPaginationAsync(BillWithPaginationRequest request, PagingParameters pagingParameters, CancellationToken cancellationToken)
        {
            var query = _dbContext.Bills
                .Join(_dbContext.Tickets, b => b.Id, t => t.BillId, (b, t) => new { b, t })
                .Join(_dbContext.ShowTimes, group => group.t.ShowTimeId, s => s.Id, (group, s) => new { group, s })
                .Join(_dbContext.ScreenTypes, group => group.s.ScreenTypeId, sct => sct.Id, (group, sct) => new { group, sct })
                .Join(_dbContext.Cinemas, group => group.group.s.CinemaId, c => c.Id, (group, c) => new { group, c })
                .Join(_dbContext.CinemaCenters, group => group.c.CinemaCenterId, cc => cc.Id, (group, cc) => new { group, cc })
                .Join(_dbContext.Schedules, group => group.group.group.group.s.ScheduleId, sc => sc.Id, (group, sc) => new { group, sc })
                .Join(_dbContext.Films, group => group.sc.FilmId, f => f.Id, (group, f) => new { group, f });

            // Thêm các điều kiện lọc
            if (!string.IsNullOrEmpty(request.FilmName))
            {
                query = query.Where(x => x.f.Name.Equals(request.FilmName));
            }
            if (!string.IsNullOrEmpty(request.BarCode))
            {
                query = query.Where(x => x.group.group.group.group.group.group.b.BarCode.Equals(request.BarCode));
            }
            if (request.Status.HasValue)
            {
                query = query.Where(x => x.group.group.group.group.group.group.b.Status == request.Status);
            }
            if (request.ShowtimeStatus.HasValue)
            {
                query = query.Where(x => x.group.group.group.group.group.s.Status == request.ShowtimeStatus);
            }
            if (!string.IsNullOrEmpty(request.CinemaType_Name))
            {
                query = query.Where(x => x.group.group.group.group.sct.Type + " " + x.group.group.cc.Name == request.CinemaType_Name);
            }
            if (request.StartTime != null && request.EndTime != null)
            {
                query = query.Where(x => x.group.group.group.group.group.group.b.CreateTime >= request.StartTime && x.group.group.group.group.group.group.b.CreateTime <= request.EndTime);
            }
            if (request.CinemaCenterId.HasValue)
            {
                query = query.Where(x => x.group.group.cc.Id == request.CinemaCenterId);
            }
            if (request.AccountId.HasValue)
            {
                query = query.Where(x => x.group.group.group.group.group.group.b.AccountId == request.AccountId);
            }

            // Thực hiện sắp xếp
            query = query
                .OrderBy(x => x.group.group.group.group.group.group.b.Status) // Sắp xếp theo Status
                .ThenByDescending(x => x.group.group.group.group.group.group.b.CreateTime); // Sắp xếp theo CreateTime

            // Tính tổng số kết quả
            var count = await query.Distinct().CountAsync(cancellationToken);

            // Lấy dữ liệu theo phân trang
            var data = await query
                .Select(x => new BillsDto
                {
                    Id = x.group.group.group.group.group.group.b.Id,
                    ShowtimeStatus = x.group.group.group.group.group.s.Status,
                    CinemaType_Name = x.group.group.group.group.sct.Type + " " + x.group.group.cc.Name,
                    FilmName = x.f.Name,
                    TotalMoney = x.group.group.group.group.group.group.b.AfterDiscount,
                    CreateTime = x.group.group.group.group.group.group.b.CreateTime,
                    BarCode = x.group.group.group.group.group.group.b.BarCode,
                    Status = x.group.group.group.group.group.group.b.Status,
                })
                .Distinct()
                .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            // Trả về kết quả phân trang
            return new PageList<BillsDto>(data, count, pagingParameters.PageNumber, pagingParameters.PageSize);
        }

    }
}