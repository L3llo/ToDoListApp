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
