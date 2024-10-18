using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using MovieTicket.Infrastructure.Implements.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Implements.Repositories.ReadWrite;

namespace MovieTicket.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            //Cấu hình DbContext
            services.AddDbContext<MovieTicketReadOnlyDbContext>();
            services.AddDbContext<MovieTicketReadWriteDbContext>();
            //Cấu hình Repo
            services.AddScoped<IComboReadOnlyRepository, ComboReadOnlyRepository>();
            services.AddScoped<IComboReadWriteRepository, ComboReadWriteRepository>();
            services.AddScoped<IBillReadOnlyRepository, BillReadOnlyRepository>();
            services.AddScoped<IBillReadWriteRepository, BillReadWriteRepository>();
            services.AddScoped<ILoginReadWriteRepository, LoginReadWriteRepository>();
            services.AddScoped<IFilmReadWriteRepository, FilmReadWriteRepository>();
            services.AddScoped<IFilmReadOnlyRepository, FilmReadOnlyRepostitory>();
            services.AddTransient<ITicketPriceReadOnlyRepository, TicketPriceReadOnlyReponsitory>();
            services.AddTransient<ITicketPriceReadWriteReponsitory, TicketPriceReadWriteReponsitory>();
            services.AddTransient<IEmailSenderReadWriteRepository, EmailSenderRepository>();
            services.AddScoped<ICinemaCenterReadOnlyRepository, CinemaCenterReadOnlyRepository>();
            services.AddScoped<ICinemaCenterReadWriteRepository, CinemaCenterReadWriteRepository>();
            services.AddScoped<IAccountReadWriteRepository, AccountReadWriteRepository>();
            services.AddScoped<IAccountReadOnlyRepository, AccountReadOnlyRepository>();
            services.AddScoped<IScheduleReadOnlyRepository, ScheduleReadOnlyRepository>();
            services.AddScoped<IScheduleReadWriteRepository, ScheduleReadWriteRepository>();
            services.AddScoped<IUserHomeReadOnlyRepository, UserHomeReadOnlyRepository>();
            services.AddScoped<IAdminHomeReadOnlyRepository, AdminHomeReadOnlyRepository>();
            services.AddScoped<IScreenTypeReadOnlyRepository, ScreenTypeReadOnlyRepository>();
            services.AddScoped<ITranslationTypeReadOnlyRepository, TranslationTypeReadOnlyRepository>();
            services.AddScoped<ICinemaReadOnlyRepository, CinemaReadOnlyRepository>();
            services.AddScoped<IBannerReadOnlyRepository, BannerReadOnlyRepository>();
            services.AddScoped<IBannerReadWriteRepository, BannerReadWriteRepository>();
            services.AddScoped<IScreeningDayReadOnlyRepository, ScreeningDayReadOnlyRepository>();
            services.AddScoped<ICinemaTypesReadOnlyRepository, CinemaTypesReadOnlyRepository>();
            services.AddScoped<ISeatTypeReadOnlyRepository, SeatTypeReadOnlyRepository>();
            services.AddScoped<ICinemaReadWriteRepository, CinemaReadWriteRepository>();
            services.AddScoped<ISeatReadOnlyRepository, SeatReadOnlyRepository>();
            services.AddScoped<ISeatReadWriteRepository, SeatReadWriteRepository>();
            services.AddScoped<IShowTimeReadOnlyRepository, ShowTimeReadOnlyRepository>();
            services.AddScoped<IShowTimeReadWriteRepository, ShowTimeReadWriteRepository>();
            return services;
        }
    }
}