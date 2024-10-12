using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using MovieTicket.BlazorServer.Authentication;
using MovieTicket.BlazorServer.Components;
using MovieTicket.BlazorServer.Services.Implements;
using MovieTicket.BlazorServer.Services.Implements.FilmService;
using MovieTicket.BlazorServer.Services.Implements.ScreenTypeService;
using MovieTicket.BlazorServer.Services.Implements.TranslationTypeService;
using MovieTicket.BlazorServer.Services.Interfaces;
using MovieTicket.BlazorServer.Services.Interfaces.IFilmService;
using MovieTicket.BlazorServer.Services.Interfaces.IScreenTypeService;
using MovieTicket.BlazorServer.Services.Interfaces.ITranslationTypeService;
using System.ComponentModel;
using System.Text;

namespace MovieTicket.BlazorServer
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:6868/") });
			builder.Services.AddRazorComponents()
				.AddInteractiveServerComponents();
			builder.Services.AddBlazoredLocalStorage();
			builder.Services.AddAuthorizationCore();
			builder.Services.AddCascadingAuthenticationState();
			builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
			builder.Services.AddScoped<IAuthenService, AuthenService>();
			builder.Services.AddScoped<IUserHomeService, UserHomeService>();
			builder.Services.AddScoped<IFilmService, FilmService>();
			builder.Services.AddScoped<IScreenTypeService, ScreenTypeService>();
			builder.Services.AddScoped<ITranslationTypeService, TranslationTypeService>();
			builder.Services.AddScoped<IFileUpload, FileUpload>();
			builder.Services.AddScoped<IAdminHomeService, AdminHomeService>();
			builder.Services.AddScoped<IScheduelService, ScheduelService>();
			builder.Services.AddAuthentication()
	           .AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>("CustomSchemeName", options => { });
			builder.Services.AddSingleton<AppState>();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseRouting();

			app.UseAuthorization();
			app.UseAntiforgery();
			app.UseStaticFiles();

			app.MapRazorComponents<App>()
				.AddInteractiveServerRenderMode();

			app.Run();
		}
	}
}