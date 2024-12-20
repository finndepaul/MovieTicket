﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.DataTransferObjs.Coupon;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Domain.Entities;
using static MovieTicket.Infrastructure.Extensions.DefaultValue;

namespace MovieTicket.API.Controllers
{
    [Route(API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountReadWriteRepository _accountReadWrite;
        private readonly IAccountReadOnlyRepository _accountReadOnly;
        private readonly IMapper _mapper;

        public AccountController(IAccountReadWriteRepository accountReadWrite, IAccountReadOnlyRepository accountOnly, IMapper mapper)
        {
            _accountReadWrite = accountReadWrite;
            _accountReadOnly = accountOnly;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Register(AccountRegisterRequest registerRequest)
        {
            var register = _mapper.Map<Account>(registerRequest);
            var check = await _accountReadWrite.RegisterAsync(register);
            return Ok(check);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAccPaging([FromQuery]PagingParameters pagingParameters)
        {
            var accounts = await _accountReadOnly.GetAllAccPaging(pagingParameters);
            var data = accounts.Item.ToList();
            return Ok(new PageList<AccountDto>(data.ToList(),
                accounts.MetaData.TotalCount,
                accounts.MetaData.CurrentPage,
                accounts.MetaData.PageSize));
        }

        [HttpGet]
        public async Task<ActionResult> GetUserCouponUsageHistoryAsync(Guid userId, [FromQuery] PagingParameters pagingParameters)
        {
            var coupons = await _accountReadOnly.GetUserCouponUsageHistoryAsync(userId, pagingParameters, new CancellationToken());
            var data = coupons.Item.ToList();
            return Ok(new PageList<CouponDto>(data.ToList(),
                coupons.MetaData.TotalCount,
                coupons.MetaData.CurrentPage,
                coupons.MetaData.PageSize));
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var accounts = await _accountReadOnly.GetAllAccount();
            return Ok(accounts);
        }

        [HttpGet]
        public async Task<ActionResult> GetAccountById(Guid Id, CancellationToken cancellationToken)
        {
            var accounts = await _accountReadOnly.GetAccountById(Id, cancellationToken);
            return Ok(accounts);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccount(AccountCreateRequest request, CancellationToken cancellationToken)
        {
            var create = await _accountReadWrite.CreateNewAccount(request, cancellationToken);
            return Ok(create);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAccount(AccountUpdateRequest request, CancellationToken cancellationToken)
        {
            var create = await _accountReadWrite.UpdateAccount(request, cancellationToken);
            return Ok(create);
        }

        [HttpPut]
	      public async Task<ActionResult> UpdateStatusAccount(Guid id, CancellationToken cancellationToken)
		    {
			      var create = await _accountReadWrite.UpdateStatusAccount(id, cancellationToken);
			      return Ok(create);
		    }
        [HttpGet]
        public async Task<ActionResult> GetMembershipPoints(Guid userId, CancellationToken cancellationToken)
        {
            var points = await _accountReadOnly.GetMembershipPointsAsync(userId, cancellationToken);
            return Ok(points);
        }
    }
}