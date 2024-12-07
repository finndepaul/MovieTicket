using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using MovieTicket.BlazorServer.Authentication;
using MovieTicket.BlazorServer.Components;
using MovieTicket.BlazorServer.Helper;
using MovieTicket.BlazorServer.Services.Implements;
using MovieTicket.BlazorServer.Services.Interfaces;
using System.Globalization;

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
            builder.Services.AddScoped<IScreenTypeServices, ScreenTypeServices>();
            builder.Services.AddScoped<ITranslationTypeService, TranslationTypeService>();
            builder.Services.AddScoped<IAdminHomeService, AdminHomeService>();
            builder.Services.AddScoped<IScheduelService, ScheduelService>();
            builder.Services.AddScoped<ICinemaService, CinemaService>();
            builder.Services.AddScoped<IBannerService, BannerService>();
            builder.Services.AddScoped<ICinemaCenterService, CinemaCenterService>();
            builder.Services.AddScoped<ITicketPriceService, TicketPriceService>();
            builder.Services.AddScoped<ICinemaTypeService, CinemaTypeService>();
            builder.Services.AddScoped<ISeatTypeService, SeatTypeService>();
            builder.Services.AddScoped<IScreeningDayService, ScreeningDayService>();
            builder.Services.AddScoped<ISeatService, SeatService>();
            builder.Services.AddScoped<IShowTimeService, ShowTimeSevice>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IComboService, ComboService>();
            builder.Services.AddScoped<IAboutService, AboutService>();
            builder.Services.AddScoped<IBillService, BillService>();
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<IBillComboService, BillComboService>();
            builder.Services.AddScoped<IAccountUtilitiesService, AccountUtilitiesService>();
            builder.Services.AddScoped<ICouponService, CouponService>();
			builder.Services.AddSingleton<GeneratorBarcode>();
			builder.Services.AddAuthentication()
               .AddScheme<AuthenticationSchemeOptions, CustomAuthenticationHandler>("CustomSchemeName", options => { });
            builder.Services.AddSingleton<AppState>();

            var cultureInfo = new CultureInfo("en-UK");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

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
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseAntiforgery();
      app.UseStaticFiles();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}