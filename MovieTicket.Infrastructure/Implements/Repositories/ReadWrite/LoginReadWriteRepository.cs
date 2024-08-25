using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieTicket.Application.DataTransferObjs.Auth;
using MovieTicket.Application.DataTransferObjs.Auth.Requests;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using MovieTicket.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class LoginReadWriteRepository : ILoginReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public LoginReadWriteRepository(MovieTicketReadWriteDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<ResponseObject<LoginDto>> Login(LoginRequest loginRequest, CancellationToken cancellationToken)
        {
            try
            {
                var account = await _dbContext.Accounts.SingleOrDefaultAsync(x => x.Username.ToLower() == loginRequest.Username.Trim().ToLower(), cancellationToken);
                if (account == null)
                {
                    return new ResponseObject<LoginDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Không tìm thấy username !!!"
                    };
                }
                if (account.Status.ToString() == AccountStatus.Inactive.ToString())
                {
                    return new ResponseObject<LoginDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Tài khoản chưa được xác thực !!!"
                    };
                }
                if (Hash.DecryptPassword(account.Password) != loginRequest.Password)
                {
                    return new ResponseObject<LoginDto>
                    {
                        Data = null,
                        Status = StatusCodes.Status400BadRequest,
                        Message = "Sai mật khẩu"
                    };
                }
                return new ResponseObject<LoginDto>
                {
                    Data = new LoginDto
                    {
                        AccessToken = GetJwtToken(account, cancellationToken).Result.AccessToken,
                        RefreshToken = GetJwtToken(account, cancellationToken).Result.RefreshToken,
                    },
                    Status = StatusCodes.Status200OK,
                    Message = "Đăng nhập thành công"
                };
            }
            catch (Exception ex)
            {
                return new ResponseObject<LoginDto>
                {
                    Data = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Error" + ex.Message
                };
            }
        }
        #region Private Method
        private JwtSecurityToken GetToken(List<Claim> lstClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInHours"], out int tokenValidityInHours);
            var expirationUTC = DateTime.Now.AddHours(tokenValidityInHours);

            var token = new JwtSecurityToken
                (
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: expirationUTC,
                    claims: lstClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            var range = RandomNumberGenerator.Create();
            range.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private async Task<LoginDto> GetJwtToken(Account account, CancellationToken cancellationToken)
        {
            var lstClaims = new List<Claim>
            {
                new Claim("Id", account.Id.ToString()),
                new Claim("Username", account.Username.ToString()),
                new Claim("Email", account.Email.ToString()),
                new Claim("Phone", account.Phone.ToString()),
                new Claim("Role", account.Role.ToString()),
                new Claim(ClaimTypes.Role,account.Role.ToString())
            };

            var jwtToken = GetToken(lstClaims);
            var refreshToken = GenerateRefreshToken();
            _ = int.TryParse(_configuration["JWT:RefreshTokenValidity"], out int refreshTokenValidity);

            RefreshToken rf = new RefreshToken
            {
                ExpiryTime = DateTime.Now.AddHours(refreshTokenValidity),
                AccountId = account.Id,
                Token = refreshToken
            };
            await _dbContext.RefreshTokens.AddAsync(rf, cancellationToken);
            await _dbContext.SaveChangesAsync();
            return new LoginDto
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                RefreshToken = refreshToken,
            };
        }
        
        
        #endregion
    }
}
