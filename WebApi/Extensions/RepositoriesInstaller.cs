using WebApi.Repositories.Ball;
using WebApi.Repositories.Color;
using WebApi.Repositories.Model;
using WebApi.Repositories.User;

namespace WebApi.Extensions
{
    public static class RepositoriesInstaller
    {
        public static void InstallAllRepositories(this IServiceCollection  services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IBallRepository, BallRepository>();
        }
    }
}
