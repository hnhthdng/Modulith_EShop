using Microsoft.EntityFrameworkCore.Diagnostics;
using Ordering.Data;
using Shared.Data;
using Shared.Data.Interceptors;

namespace Ordering
{
    public static class OrderingModule
    {
        public static IServiceCollection AddOrderingModule(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<OrderingDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseNpgsql(connectionString);
            });

            return services;
        }
        public static IApplicationBuilder UseOrderingModule(this IApplicationBuilder app)
        {
            app.UseMigration<OrderingDbContext>();
            return app;
        }
    }
}
