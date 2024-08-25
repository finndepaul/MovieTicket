using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using MovieTicket.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class AccountReadWriteRepository : IAccountReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _db;
        public AccountReadWriteRepository(MovieTicketReadWriteDbContext db)
        {
            _db = db;
        }
        public async Task<bool> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var account = await _db.Accounts.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (account != null)
            {
                if (Hash.DecryptPassword(account.Password) == request.OldPassword)
                {
                    account.Password = Hash.EncryptPassword(request.NewPassword);
                    await _db.SaveChangesAsync(cancellationToken);
                    return true;
                }
            }
            return false;
        }

        public async Task<ResponseObject<AccountDto>> CreateNewAccount(AccountCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (CheckUsernameExist(request.Username))
                {
                    return new ResponseObject<AccountDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Username đã tồn tại !!!"
                    };
                }
                if (CheckPhoneExist(request.Phone))
                {
                    return new ResponseObject<AccountDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Phone đã tồn tại !!!"
                    };
                }
                if (CheckEmailExist(request.Email))
                {
                    return new ResponseObject<AccountDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Email đã tồn tại !!!"
                    };
                }
                if (!IsEmailVaild(request.Email))
                {
                    return new ResponseObject<AccountDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Địa chỉ email sai định dạng !!!"
                    };
                }
                if (!IsPhoneVaild(request.Phone))
                {
                    return new ResponseObject<AccountDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Địa chỉ phone sai định dạng !!!"
                    };
                }
                var account = new Account
                {
                    Username = request.Username,
                    Password = Hash.EncryptPassword(request.Password),
                    Name = request.Name,
                    Phone = request.Phone,
                    Email = request.Email,
                    Role = AccountRole.User,
                    Status = AccountStatus.Inactive,
                    CreateDate = DateTime.Now
                };
                await _db.Accounts.AddAsync(account);
                await _db.SaveChangesAsync(cancellationToken);
                return new ResponseObject<AccountDto>
                {
                    Data = new AccountDto
                    {
                        Id = account.Id,
                        Username = account.Username,
                        Name = account.Name,
                        Phone = account.Phone,
                        Email = account.Email,
                        Role = account.Role,
                        Status = account.Status,
                        CreateDate = account.CreateDate
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Tạo tài khoản thành công"
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<AccountDto>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                };
            }
        }
        public async Task<ResponseObject<AccountDto>> UpdateAccount(AccountUpdateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var model = await _db.Accounts.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (model == null)
                {
                    return new ResponseObject<AccountDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status404NotFound,
                        Message = "Không tìm thấy tài khoản"
                    };
                }
                model.Avatar = request.Avatar;
                model.Name = request.Name;
                model.Email = request.Email;
                model.Phone = request.Phone;
                model.Role = request.Role;
                model.Status = request.Status;
                _db.Accounts.Update(model);
                await _db.SaveChangesAsync(cancellationToken);
                return new ResponseObject<AccountDto>
                {
                    Data = new AccountDto
                    {
                        Id = model.Id,
                        Username = model.Username,
                        Avatar = model.Avatar,
                        Name = model.Name,
                        Email = model.Email,
                        Phone = model.Phone,
                        Role = model.Role,
                        Status = model.Status,
                        CreateDate = model.CreateDate
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Cập nhật tài khoản thành công"
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<AccountDto>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                };
            }
        }
        public async Task<bool> ForgotPasswordAsync(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _db.ConfirmedEmails.FirstOrDefaultAsync(x => x.AccountId == request.AccountId && !x.IsConfirmed);
            var account = await _db.Accounts.FirstOrDefaultAsync(x => x.Id == request.AccountId);
            if (confirmEmail != null)
            {
                if (request.ConfirmPW.Trim() == confirmEmail.ConfirmCode)
                {
                    account.Password = Hash.EncryptPassword(request.NewPassword);
                    confirmEmail.IsConfirmed = true;
                    _db.ConfirmedEmails.Update(confirmEmail);
                    _db.Accounts.Update(account);
                    await _db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<Account> Register(Account account)
        {
            var accountItem = await _db.Accounts.FirstOrDefaultAsync(x=> x.Email == account.Email || x.Phone == account.Phone);
            if (accountItem != null)
            {
                return new ResponseObject<Account>
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Account is exist",
                    Data = null
                };
            }
            account.CreateDate = DateTime.Now;
            account.Role = AccountRole.User;
            account.Status = AccountStatus.Active;
            await _db.Accounts.AddAsync(account);
            await _db.SaveChangesAsync();
            return new ResponseObject<Account> 
            {
                Status = StatusCodes.Status200OK,
                Message = "Register success",
                Data = account
            };
        }

        #region Validate Method
        private bool CheckUsernameExist(string username)
        {
            return _db.Accounts.Any(x => x.Username == username);
        }
        private bool CheckPhoneExist(string phone)
        {
            return _db.Accounts.Any(x => x.Phone == phone);
        }
        private bool CheckEmailExist(string email)
        {
            return _db.Accounts.Any(x => x.Email == email);
        }
        private bool IsEmailVaild(string email)
        {
            string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email,emailPattern);
        }
        private bool IsPhoneVaild(string phone)
        {
            string phonePattern = @"^0\d{9}$";
            return Regex.IsMatch(phone, phonePattern);
        }
        #endregion
    }

}
