using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.DataTransferObjs.Auth.Requests;
using MovieTicket.BlazorServer.Authentication;
using MovieTicket.BlazorServer.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;
using static MovieTicket.Application.ValueObjs.ViewModels.CustomReponses;

namespace MovieTicket.BlazorServer.Services.Implements
{
    public class AuthenService : IAuthenService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorageService;
        private readonly IConfiguration configuration;
        private readonly ProtectedLocalStorage protectedLocalStorage;
        private readonly ProtectedSessionStorage protectedSessionStorage;
        private readonly NavigationManager navigationManager;

        public AuthenService(ProtectedLocalStorage protectedLocalStorage,
            NavigationManager navigationManager,
            IConfiguration configuration,
            HttpClient httpClient,
            ILocalStorageService localStorageService,
            ProtectedSessionStorage protectedSessionStorage
            )
        {
            this.configuration = configuration;
            this.protectedLocalStorage = protectedLocalStorage;
            this.navigationManager = navigationManager;
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
            this.protectedSessionStorage = protectedSessionStorage;
        }

        public async Task<LoginRespone> LoginAsync(LoginDTO loginModel)
        {
            var response = await httpClient.PostAsJsonAsync("https://localhost:6868/api/Auth/Login", loginModel);
            var result = await response.Content.ReadFromJsonAsync<LoginRespone>();
            //await localStorageService.SetItemAsync(JWTToken, result.JWTToken);
            Constants.Token = result.JWTToken;
            //await protectedSessionStorage.SetAsync(JWTToken, result.JWTToken);
            return result;
        }

        public async Task<RegisterResponse> RegisterAsync(AccountRegisterRequest registerModel)
        {
            if (Constants.Token != "") return null!;
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Constants.Token);
            var response = await httpClient.PostAsJsonAsync("https://localhost:6868/api/Account/Register", registerModel);
            var result = await response.Content.ReadFromJsonAsync<RegisterResponse>();
            return result;
        }

        public async Task<LoginRespone> RefreshToken(UserSession session)
        {
            var response = await httpClient.PostAsJsonAsync("https://localhost:6868/api/Auth/RefreshToken", session);
            var result = await response.Content.ReadFromJsonAsync<LoginRespone>();
            return result;
        }

        private void GetProtectedClient()
        {
            if (Constants.Token == "") return;
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Constants.Token);
        }

        private static bool CheckIfUnauthorized(HttpResponseMessage message)
        {
            if (message.StatusCode == HttpStatusCode.Unauthorized)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task GetRefreshToken()
        {
            var response = await httpClient.PostAsJsonAsync("https://localhost:6868/api/Auth/RefreshToken", new UserSession() { JWTToken = Constants.Token });
            var result = await response.Content.ReadFromJsonAsync<LoginRespone>();
            Constants.Token = result!.JWTToken;
        }

        public async Task Logout()
        {
            //await protectedSessionStorage.DeleteAsync(JWTToken);
            Constants.Token = "";
            CustomAuthenticationStateProvider customAuthStateProvider = new CustomAuthenticationStateProvider();
            await customAuthStateProvider.GetAuthenticationStateAsync();
            await customAuthStateProvider.UpdateAuthenticationState("");
            httpClient.DefaultRequestHeaders.Authorization = null;
            httpClient.DefaultRequestHeaders.Remove("Authorization");
            navigationManager.NavigateTo("/", forceLoad: true);
        }
    }
}