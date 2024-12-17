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
using System.Text.RegularExpressions;
using static MovieTicket.Application.ValueObjs.ViewModels.CustomReponses;

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
				var membership = new Membership
				{
					Id = account.Id,
					Point = 0,
					Status = MembershipStatus.Active
				};
				await _db.Memberships.AddAsync(membership);
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
                model.CinemaCenterId = request.CinemaCenterId;
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

        public async Task<ResponseObject<bool>> ForgotPasswordAsync(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _db.ConfirmedEmails.FirstOrDefaultAsync(x => x.AccountId == request.AccountId && !x.IsConfirmed);
            var account = await _db.Accounts.FirstOrDefaultAsync(x => x.Id == request.AccountId);
            if (confirmEmail != null)
            {
                if (request.ConfirmPW.Trim() == confirmEmail.ConfirmCode)
                {
                    if (confirmEmail.ExpiryTime <= DateTime.Now)
                    {
                        _db.ConfirmedEmails.Remove(confirmEmail);
                        await _db.SaveChangesAsync();
                        return new ResponseObject<bool>()
                        {
                            Message = "Mã xác nhận này đã quá hạn",
                            Status = StatusCodes.Status400BadRequest,
                            Data = false
                        };
                    }
                    account.Password = Hash.EncryptPassword(request.NewPassword);
                    confirmEmail.IsConfirmed = true;
                    _db.ConfirmedEmails.Update(confirmEmail);
                    await _db.SaveChangesAsync();
                    _db.Accounts.Update(account);
                    await _db.SaveChangesAsync();
                    return new ResponseObject<bool>()
                    {
                        Message = "Đổi mật khẩu thành công",
                        Status = StatusCodes.Status200OK,
                        Data = true
                    };
                }
				return new ResponseObject<bool>()
				{
					Message = "Mã xác nhận không đúng",
					Status = StatusCodes.Status400BadRequest,
					Data = false
				};
            }
			return new ResponseObject<bool>()
			{
				Message = "Không tìm thấy yêu cầu xác nhận",
				Status = StatusCodes.Status400BadRequest,
				Data = false
			};
		}

        public async Task<RegisterResponse> RegisterAsync(Account account)
        {
            var accountItem = await _db.Accounts.FirstOrDefaultAsync(x => x.Email == account.Email || x.Phone == account.Phone);
            if (accountItem != null)
            {
                return new RegisterResponse
                {
                    Flag = false,
                    Message = "Email hoặc số điện thoại đã tồn tại"
                };
            }
            account.CreateDate = DateTime.Now;
            account.Role = AccountRole.User;
            account.Status = AccountStatus.Inactive;
            account.Password = Hash.EncryptPassword(account.Password);
            await _db.Accounts.AddAsync(account);
            await _db.SaveChangesAsync();
            var membership = new Membership
			{
				Id = Guid.NewGuid(),
                AccountId = account.Id,
                Point = 0,
				Status = MembershipStatus.Active
			};
			await _db.Memberships.AddAsync(membership);
			await _db.SaveChangesAsync();
			//return new ResponseObject<Account>
			//{
			//    Status = StatusCodes.Status200OK,
			//    Message = "Register success",
			//    Data = account
			//};
			return new RegisterResponse
            {
                Flag = true,
                Message = "Đăng ký thành công"
            };
        }
		public async Task<bool> UpdateStatusAccount(Guid id, CancellationToken cancellationToken)
		{
			var account = _db.Accounts.FirstOrDefault(x => x.Id == id);
			if (account != null)
			{
				account.Status = AccountStatus.Active;
			    _db.Accounts.Update(account);
				await _db.SaveChangesAsync(cancellationToken);
                return true;
			}
			return false;
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
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsPhoneVaild(string phone)
        {
            string phonePattern = @"^0\d{9}$";
            return Regex.IsMatch(phone, phonePattern);
        }
		#endregion Validate Method
	}
}