using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Application.ValueObjs.ViewModels;

namespace MovieTicket.BlazorServer.Services.Interfaces
{
    public interface IAccountService
    {
        Task<PageList<AccountDto>> GetAllAccPaginition(PagingParameters pagingParameters);
        Task<IEnumerable<AccountDto>> GetAllAsync();
        Task<AccountDto> GetByIdAsync(Guid id);
        Task<ResponseObject<AccountDto>> CreateAsync(AccountCreateRequest accountCreateRequest);
        Task<AccountDto> UpdateAsync(AccountUpdateRequest accountUpdateRequest);
        Task<bool> UpdateStatusAccount(Guid id);
	}
}
