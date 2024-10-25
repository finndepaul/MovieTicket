using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.ValueObjs.ViewModels;
using MovieTicket.BlazorServer.Services.Interfaces;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<IEnumerable<AccountDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<AccountDto>>("api/Account/GetAll");
        }

        public async Task<AccountDto> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<AccountDto>($"api/Account/GetAccountById?Id={id}");
        }
        public async Task<ResponseObject<AccountDto>> CreateAsync(AccountCreateRequest accountCreateRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Account/CreateAccount", accountCreateRequest);
            var readObj = await response.Content.ReadFromJsonAsync<ResponseObject<AccountDto>>();
            return new ResponseObject<AccountDto>()
            {
                Data = readObj.Data,
                Message = readObj.Message,
                Status = readObj.Status
            };
        }
        public async Task<AccountDto> UpdateAsync(AccountUpdateRequest accountUpdateRequest)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Account/UpdateAccount", accountUpdateRequest);
            return await response.Content.ReadFromJsonAsync<AccountDto>();
        }
    }
}
