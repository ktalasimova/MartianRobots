using MartianRobots.Domain.Repositories;
using MartianRobots.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MartianRobots.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString, string migrationsAssembly = "")
        {
            services.AddDbContext<MartianRobotsDbContext>(options => options.UseSqlServer(connectionString, sql =>
            {
                if (!string.IsNullOrEmpty(migrationsAssembly))
                {
                    sql.MigrationsAssembly(migrationsAssembly);
                }
            })).AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            return services;
        }

        public static void MigrateGamesDb(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.GetRequiredService<MartianRobotsDbContext>().Database.Migrate();
        }
    }
}
