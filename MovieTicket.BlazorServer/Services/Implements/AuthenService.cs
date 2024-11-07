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
		private const string JWTToken = nameof(JWTToken);

		private readonly HttpClient httpClient;
		private readonly ILocalStorageService localStorageService;
		private readonly IConfiguration configuration;
		private readonly ProtectedLocalStorage protectedLocalStorage;
		private readonly NavigationManager navigationManager;

		public AuthenService(ProtectedLocalStorage protectedLocalStorage, NavigationManager navigationManager, IConfiguration configuration, HttpClient httpClient)
		{
			this.configuration = configuration;
			this.protectedLocalStorage = protectedLocalStorage;
			this.navigationManager = navigationManager;
			this.httpClient = httpClient;
		}

		public async Task<LoginRespone> LoginAsync(LoginDTO loginModel)
		{
			var response = await httpClient.PostAsJsonAsync("https://localhost:6868/api/Auth/Login", loginModel);
			var result = await response.Content.ReadFromJsonAsync<LoginRespone>();
			await protectedLocalStorage.SetAsync(JWTToken, result.JWTToken);
			return result;
		}

		public async Task<RegisterResponse> RegisterAsync(AccountRegisterRequest registerModel)
		{
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
			if (Constants.JWTToken == "") return;
			httpClient.DefaultRequestHeaders.Authorization =
				new AuthenticationHeaderValue("Bearer", Constants.JWTToken);
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
			var response = await httpClient.PostAsJsonAsync("https://localhost:6868/api/Auth/RefreshToken", new UserSession() { JWTToken = Constants.JWTToken });
			var result = await response.Content.ReadFromJsonAsync<LoginRespone>();
			Constants.JWTToken = result!.JWTToken;
		}

		public async Task Logout()
		{
			await protectedLocalStorage.DeleteAsync(JWTToken);
			Constants.JWTToken = "";
			CustomAuthenticationStateProvider customAuthStateProvider = new CustomAuthenticationStateProvider(localStorageService);
			await customAuthStateProvider.GetAuthenticationStateAsync();
			customAuthStateProvider.UpdateAuthenticationState("");
			httpClient.DefaultRequestHeaders.Authorization = null;
			httpClient.DefaultRequestHeaders.Remove("Authorization");
			navigationManager.NavigateTo("/");
		}
	}
}