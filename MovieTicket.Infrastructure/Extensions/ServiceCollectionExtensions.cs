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
            services.AddScoped<MovieTicketReadOnlyDbContext>();
            services.AddScoped<MovieTicketReadWriteDbContext>();
            services.AddScoped<ICinemaCenterReadOnlyRepository, CinemaCenterReadOnlyRepository>();
            services.AddScoped<ICinemaCenterReadWriteRepository, CinemaCenterReadWriteRepository>();
            services.AddScoped<IAccountReadWriteRepository, AccountReadWriteRepository>();
            return services;
        }
    }
}