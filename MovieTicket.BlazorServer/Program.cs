using MovieTicket.BlazorServer.Components;
using MovieTicket.BlazorServer.Services.Implements;
using MovieTicket.BlazorServer.Services.Implements.FilmService;
using MovieTicket.BlazorServer.Services.Implements.ScreenTypeService;
using MovieTicket.BlazorServer.Services.Implements.TranslationTypeService;
using MovieTicket.BlazorServer.Services.Interfaces;
using MovieTicket.BlazorServer.Services.Interfaces.IFilmService;
using MovieTicket.BlazorServer.Services.Interfaces.IScreenTypeService;
using MovieTicket.BlazorServer.Services.Interfaces.ITranslationTypeService;

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
            builder.Services.AddHttpClient();
			builder.Services.AddScoped<IUserHomeService, UserHomeService>();
			builder.Services.AddScoped<IFilmService, FilmService>();
            builder.Services.AddScoped<IScreenTypeService, ScreenTypeService>();
            builder.Services.AddScoped<ITranslationTypeService, TranslationTypeService>();
            builder.Services.AddScoped<IFileUpload, FileUpload>();
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
