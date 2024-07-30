using Microsoft.EntityFrameworkCore;
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
            services.AddScoped<IFilmReadWriteRepository, FilmReadWriteRepository>();
            services.AddScoped<IFilmReadOnlyRepository, FilmReadOnlyRepostitory>();
            services.AddScoped<MovieTicketReadOnlyDbContext>();
            services.AddScoped<MovieTicketReadWriteDbContext>();
            //services.AddDbContext<MovieTicketReadOnlyDbContext>(options =>
            //{
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            //});
            //services.AddDbContext<MovieTicketReadWriteDbContext>(options =>
            //{
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            //});
            return services;
        }
    }
}