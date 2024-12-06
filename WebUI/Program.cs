using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;
using WebUI.Authentication;
using WebUI.Services.Implements;
using WebUI.Services.Interfaces;

namespace WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:6868/") });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<CustomAuthenticationStateProvider>();
            builder.Services.AddScoped<IAuthenService, AuthenService>();
            builder.Services.AddScoped<IAdminHomeService, AdminHomeService>();
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
            var cultureInfo = new CultureInfo("en-UK");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            await builder.Build().RunAsync();
        }
    }
}
