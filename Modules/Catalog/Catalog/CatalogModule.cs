using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Catalog
{
    public static class CatalogModule
    {
        public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)
        {
            // Data - Infrastructure services
            var connectionString = configuration.GetConnectionString("Database");

            
            services.AddDbContext<CatalogDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseNpgsql(connectionString);
            });

            return services;
        }
        public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
