﻿using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Coupon;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Infrastructure.Database.AppDbContexts;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadOnly
{
    public class AccountReadOnlyRepository : IAccountReadOnlyRepository
    {
        private readonly MovieTicketReadOnlyDbContext _context;

        public AccountReadOnlyRepository(MovieTicketReadOnlyDbContext context)
        {
            _context = context;
        }

        public async Task<AccountDto> GetAccountById(Guid Id, CancellationToken cancellationToken)
        {
            var model = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
            return new AccountDto
            {
                Id = model.Id,
                Avatar = model.Avatar,
                Name = model.Name,
                Username = model.Username,
                Email = model.Email,
                Phone = model.Phone,
                Role = model.Role,
                Status = model.Status,
                CreateDate = model.CreateDate,
                CinemaCenterId = model.CinemaCenterId
            };
        }

        public async Task<IQueryable<AccountDto>> GetAllAccount()
        {
            return _context.Accounts
                .Select(x => new AccountDto
                {
                    Id = x.Id,
                    Username = x.Username,
                    Avatar = x.Avatar,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Role = x.Role,
                    Status = x.Status,
                    CreateDate = x.CreateDate,
                    CinemaCenterId = x.CinemaCenterId
                })
                .AsNoTracking();
        }

        public async Task<PageList<AccountDto>> GetAllAccPaging(PagingParameters pagingParameters)
        {
            var query = _context.Accounts
                .Select(x => new AccountDto
                {
                    Id = x.Id,
                    Username = x.Username,
                    Avatar = x.Avatar,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Role = x.Role,
                    Status = x.Status,
                    CreateDate = x.CreateDate
                })
                .AsNoTracking();

            var count = await query.CountAsync();
            var items = await query
                .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .ToListAsync();

            return new PageList<AccountDto>(items, count, pagingParameters.PageNumber, pagingParameters.PageSize);
        }

        public async Task<PageList<CouponDto>> GetUserCouponUsageHistoryAsync(Guid userId, PagingParameters pagingParameters, CancellationToken cancellationToken)
        {
            var query = _context.Bills
                .Where(b => b.Account.Id == userId && b.CouponId != null)
                .Select(b => new CouponDto
                {
                    CouponCode = b.Coupon.CouponCode,
                    AmountValue = b.Coupon.AmountValue,
                    StartDate = b.Coupon.StartDate,
                    EndDate = b.Coupon.EndDate,
                    IsActive = b.Coupon.IsActive ? "Active" : "Inactive"
                })
                .AsNoTracking();

            var count = await query.CountAsync(cancellationToken);
            var items = await query
                .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize)
                .ToListAsync(cancellationToken);

            return new PageList<CouponDto>(items, count, pagingParameters.PageNumber, pagingParameters.PageSize);
        }

        public async Task<int> GetMembershipPointsAsync(Guid userId, CancellationToken cancellationToken)
        {
            var membershipPoints = await (from membership in _context.Memberships
                                          join account in _context.Accounts
                                          on membership.Account.Id equals account.Id
                                          where account.Id == userId
                                          select membership.Point)
                                           .FirstOrDefaultAsync(cancellationToken);

            return membershipPoints ?? 0;
        }

    }
}