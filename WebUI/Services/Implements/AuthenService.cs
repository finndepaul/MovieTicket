using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MovieTicket.Application.DataTransferObjs.Account;
using MovieTicket.Application.DataTransferObjs.Account.Request;
using MovieTicket.Application.DataTransferObjs.Auth.Requests;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using WebUI.Authentication;
using WebUI.Services.Interfaces;
using static MovieTicket.Application.ValueObjs.ViewModels.CustomReponses;

namespace WebUI.Services.Implements
{
    public class AuthenService : IAuthenService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorageService;
        private readonly IConfiguration configuration;
        private readonly NavigationManager navigationManager;
        private AuthenticationStateProvider AuthenticationStateProvider;

        public AuthenService(
            NavigationManager navigationManager,
            IConfiguration configuration,
            HttpClient httpClient,
            ILocalStorageService localStorageService,
            AuthenticationStateProvider authenticationStateProvider)
        {
            this.configuration = configuration;
            this.navigationManager = navigationManager;
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
            AuthenticationStateProvider = authenticationStateProvider;
        }

        public async Task<LoginRespone> LoginAsync(LoginDTO loginModel)
        {
            var response = await httpClient.PostAsJsonAsync("https://localhost:6868/api/Auth/Login", loginModel);
            var result = await response.Content.ReadFromJsonAsync<LoginRespone>();

            await localStorageService.SetItemAsync("authToken", result.JWTToken);

            return result;
        }

        public async Task<RegisterResponse> RegisterAsync(AccountRegisterRequest registerModel)
        {
            //var token = await localStorageService.GetItemAsync<string>("authToken");
            //if (token != "") return null!;
            //httpClient.DefaultRequestHeaders.Authorization =
            //    new AuthenticationHeaderValue("Bearer", token);
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

        //private void GetProtectedClient()
        //{
        //    if (Constants.Token == "") return;
        //    httpClient.DefaultRequestHeaders.Authorization =
        //        new AuthenticationHeaderValue("Bearer", Constants.Token);
        //}

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

        //private async Task GetRefreshToken()
        //{
        //    var response = await httpClient.PostAsJsonAsync("https://localhost:6868/api/Auth/RefreshToken", new UserSession() { JWTToken = Constants.Token });
        //    var result = await response.Content.ReadFromJsonAsync<LoginRespone>();
        //    Constants.Token = result!.JWTToken;
        //}

        public async Task Logout()
        {
            await localStorageService.RemoveItemAsync("authToken");
            httpClient.DefaultRequestHeaders.Authorization = null;
            httpClient.DefaultRequestHeaders.Remove("Authorization");
            CustomAuthenticationStateProvider customAuthStateProvider = new CustomAuthenticationStateProvider(localStorageService, httpClient);
            await customAuthStateProvider.GetAuthenticationStateAsync();
            await customAuthStateProvider.UpdateAuthenticationState("");
            navigationManager.NavigateTo("/", forceLoad: true);
        }
    }
}