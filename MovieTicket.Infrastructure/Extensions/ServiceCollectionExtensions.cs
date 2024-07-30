using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.Interfaces.Services.ReadOnly;
using MovieTicket.Application.Interfaces.Services.ReadWrite;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using MovieTicket.Infrastructure.Implements.Repositories.ReadOnly;
using MovieTicket.Infrastructure.Implements.Repositories.ReadWrite;
using MovieTicket.Infrastructure.Implements.Services.ReadOnly;
using MovieTicket.Infrastructure.Implements.Services.ReadWrite;

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
            services.AddScoped<IRComboRepository, RComboRepository>();
            services.AddScoped<IRBillRepository, RBillRepository>();
            services.AddScoped<IRWComboRepository, RWComboRepository>();
            services.AddScoped<IRWBillRepository, RWBillRepository>();

            //Cấu hình Service
            services.AddScoped<IRComboService, RComboService>();
            services.AddScoped<IRWComboService, RWComboService>();
            services.AddScoped<IRBillService, RBillService>();
            services.AddScoped<IRWBillService, RWBillService>();

            return services;
        }
    }
}