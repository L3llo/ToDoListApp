using Microsoft.EntityFrameworkCore;
using ToDoListApp.Server.Application.ToDoItems;
using ToDoListApp.Server.Application.ToDoItems.Interfaces;
using ToDoListApp.Server.Infrastructure.Persistence;
using ToDoListApp.Server.Infrastructure.Persistence.Repositories;

namespace ToDoListApp.Server.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment environment)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                // Same retry/timeout tuning in both branches, but UseAzureSql (vs. UseSqlServer) is required
                // in production because the free-tier Azure SQL instance auto-pauses when idle and can take
                // up to ~30s to resume; the generous retry count/delay ride out that cold start.
                if (environment.IsDevelopment())
                {
                    options.UseSqlServer(connectionString, sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                        sqlOptions.CommandTimeout(60);
                    });
                }
                else
                {
                    options.UseAzureSql(connectionString, sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                        sqlOptions.CommandTimeout(60);
                    });
                }
            });

            services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
            services.AddScoped<IToDoItemService, ToDoItemService>();

            return services;
        }
    }
}
