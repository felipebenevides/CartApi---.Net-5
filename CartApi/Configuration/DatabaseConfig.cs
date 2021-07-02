using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CartApi.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var serviceProvider = services.BuildServiceProvider();

            if (services == null) throw new ArgumentNullException(nameof(services));

            if (services == null) throw new ArgumentNullException(nameof(services));


            services.AddDbContext<CartDbContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ApiCartDB"), providerOptions => providerOptions.EnableRetryOnFailure());
            });
        }
    }
}
