using Microsoft.EntityFrameworkCore;
using WebApi.Context;

namespace WebApi.Extensions
{
    public static class ContextInstaller
    {
        public static void InstallMySql(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DefaultDbContext>(options =>
            {
                options.UseMySql(connectionString, serverVersion: ServerVersion.AutoDetect(connectionString));
            });
        }

        public static void InstallSqlServer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DefaultDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
        }
    }
}
