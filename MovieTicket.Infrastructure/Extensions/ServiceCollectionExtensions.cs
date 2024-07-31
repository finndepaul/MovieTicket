﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Infrastructure.Database.AppDbContexts;
using MovieTicket.Infrastructure.Implements.Repositories.ReadWrite;

namespace MovieTicket.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<MovieTicketReadWriteDbContext>();

            services.AddScoped<MovieTicketReadOnlyDbContext>();
            services.AddTransient<IAccountPasswordRepository, AccountPasswordRepository>();
            services.AddTransient<ISendEmailRepository, SendEmailRepository>();
            return services;
        }
    }
}