using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Account.Request;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<AccountDto>> GetAllAsync();
        Task<AccountDto> GetByIdAsync(Guid id);
        Task<AccountDto> CreateAsync(AccountCreateRequest accountCreateRequest);
        Task<AccountDto> UpdateAsync(AccountUpdateRequest accountUpdateRequest);
    }
}
