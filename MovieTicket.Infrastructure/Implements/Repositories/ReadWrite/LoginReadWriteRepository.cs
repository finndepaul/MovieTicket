using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Auth;
using MovieTicket.Application.DataTransferObjs.Auth.Requests;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Domain.Entities;
using MovieTicket.Domain.Enums;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using MovieTicket.Infrastructure.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static MovieTicket.Application.ValueObjs.ViewModels.CustomReponses;

namespace MovieTicket.Infrastructure.Implements.Repositories.ReadWrite
{
    public class LoginReadWriteRepository : ILoginReadWriteRepository
    {
        private readonly MovieTicketReadWriteDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public LoginReadWriteRepository()
        {
        }

        public LoginReadWriteRepository(MovieTicketReadWriteDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        private async Task<Account> GetUser(string username)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower());
        }

        public async Task<LoginRespone> LoginAsync(LoginDTO loginModel)
        {
            try
            {
                var account = await GetUser(loginModel.Username);
                if (account == null)
                {
                    return new LoginRespone
                    {
                        Flag = false,
                        Message = "Không tìm thấy username !!!",
                        JWTToken = null
                    };
                }
                if (account.Status.ToString() == AccountStatus.Inactive.ToString())
                {
                    return new LoginRespone
                    {
                        Flag = false,
                        Message = "Tài khoản chưa được xác thực !!!",
                        JWTToken = null
                    };
                }
                if (Hash.DecryptPassword(account.Password) != loginModel.Password)
                {
                    return new LoginRespone
                    {
                        Flag = false,
                        Message = "Sai mật khẩu",
                        JWTToken = null
                    };
                }
                string jwtToken = GenerateToken(account);
                return new LoginRespone
                {
                    Flag = true,
                    Message = "Đăng nhập thành công",
                    JWTToken = jwtToken
                };
            }
            catch (Exception ex)
            {
                return new LoginRespone
                {
                    Flag = false,
                    Message = "Error" + ex.Message,
                    JWTToken = null
                };
            }
        }

        public LoginRespone RefreshToken(UserSession userSession)
        {
            CustomeUserClaims claims = DecryptJWTService.DecryptToken(userSession.JWTToken);
            if (claims == null)
            {
                return new LoginRespone(false, "Token is invalid", null);
            }
            string newJWTToken = GenerateToken(new Account
            {
                Username = claims.Username,
                Email = claims.Email,
                Role = Enum.Parse<AccountRole>(claims.Role) // Fix for CS0029
            });
            return new LoginRespone(true, "New token", newJWTToken);
        }

        public async Task<LoginRespone> UserInfo(UserSession userSession)
        {
            CustomeUserClaims claims = DecryptJWTService.DecryptToken(userSession.JWTToken);
            if (claims == null)
            {
                return new LoginRespone(false, "Token is invalid", null);
            }
            var account = await GetUser(claims.Username);
            if (account == null)
            {
                return new LoginRespone(false, "Không tìm thấy username !!!", null);
            }
            return new LoginRespone(true, "Success", account.Username);
        }

        //public async Task<ResponseObject<LoginDto>> Login(LoginDTO loginModel, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var account = await _dbContext.Accounts.SingleOrDefaultAsync(x => x.Username.ToLower() == loginModel.Username.Trim().ToLower(), cancellationToken);
        //        if (account == null)
        //        {
        //            return new ResponseObject<LoginDto>
        //            {
        //                Data = null,
        //                Status = StatusCodes.Status400BadRequest,
        //                Message = "Không tìm thấy username !!!"
        //            };
        //        }
        //        if (account.Status.ToString() == AccountStatus.Inactive.ToString())
        //        {
        //            return new ResponseObject<LoginDto>
        //            {
        //                Data = null,
        //                Status = StatusCodes.Status400BadRequest,
        //                Message = "Tài khoản chưa được xác thực !!!"
        //            };
        //        }
        //        if (Hash.DecryptPassword(account.Password) != loginModel.Password)
        //        {
        //            return new ResponseObject<LoginDto>
        //            {
        //                Data = null,
        //                Status = StatusCodes.Status400BadRequest,
        //                Message = "Sai mật khẩu"
        //            };
        //        }
        //        return new ResponseObject<LoginDto>
        //        {
        //            Data = new LoginDto
        //            {
        //                AccessToken = GetJwtToken(account, cancellationToken).Result.AccessToken,
        //                RefreshToken = GetJwtToken(account, cancellationToken).Result.RefreshToken,
        //            },
        //            Status = StatusCodes.Status200OK,
        //            Message = "Đăng nhập thành công"
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResponseObject<LoginDto>
        //        {
        //            Data = null,
        //            Status = StatusCodes.Status500InternalServerError,
        //            Message = "Error" + ex.Message
        //        };
        //    }
        //}

        #region Private Method

        private string GenerateToken(Account account)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Username),
                new Claim(ClaimTypes.Role, account.Role.ToString()),
                new Claim(ClaimTypes.Email, account.Email)
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JWT:TokenValidityInMinutes"])),
                signingCredentials: signinCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GetToken(List<Claim> lstClaims) //=GenerateToken()
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

        private async Task<LoginDto> GetJwtToken(Account account, CancellationToken cancellationToken) //=GenerateToken()
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

        #endregion Private Method
    }
}